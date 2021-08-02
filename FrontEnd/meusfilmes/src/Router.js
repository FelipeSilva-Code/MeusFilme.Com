import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import Login from "./Pages/Login";
import Home from "./Pages/Home";
import Cadastro from "./Pages/Cadastrar";
import { AuthProvider, Context } from "./Contexts/AuthContext";
import Inicio from "./Pages/Inicio";
import { useContext } from "react";
import UsuarioService from "./Services/UsuarioService";
import InserirAtor from "./Pages/InserirAtor";
import InserirDiretor from "./Pages/InserirDiretor";


export default function Router() {

  function CustonRoute({ isPrivate, ...rest }) {
    const { isLoading, isAutenticado, isTerminouReq } = useContext(Context);
 
    if (isLoading) {
      return <h1>Carregando</h1>;
    } 
 
    if (!isPrivate && isAutenticado) {
      return <Redirect to="/inicio" />;
    } else if (isPrivate && !isAutenticado && isTerminouReq) {
      return <Redirect to="/login" />;
    } else if(isPrivate && isAutenticado && isTerminouReq) {
      return <Route {...rest} />;
    }
    
  }

  return (
    <BrowserRouter>
     <AuthProvider>
       <Switch>
          <CustonRoute path="/" exact component={Home} />
          <CustonRoute path="/login" exact component={Login} />
          <CustonRoute path="/cadastro" exact component={Cadastro} />
          <CustonRoute isPrivate path="/inicio" exact component={Inicio} />
          <CustonRoute isPrivate path="/inserir/ator" exact component={InserirAtor} />
          <CustonRoute isPrivate path="/inserir/diretor" exact component={InserirDiretor} />
        </Switch>
      </AuthProvider>
    </BrowserRouter>
  );
}
