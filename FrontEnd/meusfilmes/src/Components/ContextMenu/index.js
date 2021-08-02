import react, { useContext } from 'react';
import { Context } from '../../Contexts/AuthContext';
import {MenuInfo} from "./styled" 
import ImageIndis from "../../Assets/Images/indisponivel.jpg";
import { Link } from 'react-router-dom';
import swal from "sweetalert";


export default function ContextMenu () {

    const {usuario, logout} = useContext(Context)

    const sair = () => {
      swal({
        title: "Você tem certeza de que deseja sair?",
        icon: "warning",
        buttons: ["Cancelar", "Sair"],
        dangerMode: true,
      }).then((willDelete) => {
        if (willDelete) 
          logout();
         
      });
    }
    return (
      <MenuInfo style={{marginTop : usuario.permissao === "Adm" ? "45vh" : "30vh"}}>
        <div className="topo-info">
          <div className="d-icon">
            <img className="icon" alt="icon" src={ImageIndis}></img>
          </div>
          <div className="d-info">
            <h6 className="name">{usuario.nome}</h6>
          </div>
        </div>
        {usuario.permissao === "Adm" && (
          <div className="middle">
            <Link className="link" to="/inserir/ator">Adicionar Ator</Link>
            <Link className="link" to="">Adicionar Filme</Link>
            <Link className="link" to="/inserir/diretor">Adicionar Diretor</Link>
            <Link className="link">Adicionar Personagem</Link>
          </div>
        )}
        <div className="bottom">
          <Link className="link">Gerenciar Conta</Link>
          <p onClick={sair}>Sair</p>
        </div>
      </MenuInfo>
    );
}