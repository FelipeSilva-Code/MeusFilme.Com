import { api } from "./Api";

export default class UsuarioService {
    
    cadastrarUsuario = async (request) =>{

        let resp = await api.post("usuario/cadastro", request);
        return resp.data;
    }

    validarToken = async () => 
    {
        const resp = await api.get("/usuario/validar", {
          headers: {
            Authorization: `Bearer ${JSON.parse(
              localStorage.getItem("token")
            )}`,
          },
        });
        
        return resp.data;
        
    }
}

