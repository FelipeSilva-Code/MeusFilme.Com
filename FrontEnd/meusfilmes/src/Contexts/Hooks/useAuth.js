import { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { api } from "../../Services/Api";
import UsuarioService from "../../Services/UsuarioService";
import { useAlert } from "react-alert";

export default function useAuth() {
  const usuarioService = new UsuarioService();
  const [isAutenticado, setIsAutenticado] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const [isTerminouReq, setIsTerminouReq ] = useState(false);
  const [usuario, setUsuario] = useState({
    id: 0,
    nome: "",
    email: "",
    permissao: "",
  });

  const alert = useAlert();
  const history = useHistory();


  //TODO RETORNAR INFO USUARIO NA VALIDAÇÃO DE TOKEN, PORQUE A CADA F5 AS INFO GLOBAIS SÃO REINICIDAS COM O VALOR DEFAULT
  useEffect(()  => {

    async function validarToken(){
        const token = localStorage.getItem("token");

        //Valida se existe token salvo no local storage
        if (token) {
            //Valida se o token salvo ainda é válido
            const resp = await usuarioService.validarToken();

            if (resp) {
            api.defaults.headers.Authorization = `Bearer ${JSON.parse(
                token
            )}`;
            setUsuario(resp)
            setIsAutenticado(true);
            setIsTerminouReq(true);
            }
        }else{
            setIsTerminouReq(true);
        }


    }

    validarToken();
    setIsLoading(false);
  
  }, []);



  const logar = async (infoLogin) => {
    try {
      const {
        data: { token, usuario },
      } = await api.post("/usuario/login", infoLogin);

      localStorage.setItem("token", `${JSON.stringify(token)}`);

      api.defaults.headers.Authorization = `Bearer ${token}`;
      setIsAutenticado(true);
      
      setUsuario(usuario);
      history.push("/inicio");
    } catch (e) {
      console.log(e)
      alert.error(e.response.data.mensagem);
    }
  };

  //Desloga o usuário, setando todas as info dele
  const logout = async () => {
    setIsAutenticado(false);
    localStorage.removeItem("token");
    api.defaults.headers.Authorization = undefined;
    setUsuario({ id: 0, nome: "", email: "", permissao: "" });
    history.push("/login");
  };

  return { isAutenticado, isLoading, logar, logout, usuario, isTerminouReq };
}