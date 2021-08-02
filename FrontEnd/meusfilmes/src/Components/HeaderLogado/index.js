import React, { useContext, useState } from "react";
import { Link } from "react-router-dom";
import {CompHeader} from "./styled"
import ImageIndis from "../../Assets/Images/indisponivel.jpg";
import { Context } from "../../Contexts/AuthContext";
import ContextMenu from "../ContextMenu";


export default function HeaderOn ({image}) {
    const { usuario, logout } = useContext(Context);

    const [showMenuContext, setShowMenuContext] = useState(false);

    const showMenu = () => {

      console.log("oi")
      if (showMenuContext === false) 
          setShowMenuContext(true);
      else 
          setShowMenuContext(false);
    };

    return (
      <CompHeader>
        <Link className="link" to="/inicio">
          <h2>MeusFilmes.Com</h2>
        </Link>

        <div className="links-outrasTelas">
          <Link to={"/inicio"} className="link">
            Início
          </Link>
          <Link className="link">Filmes</Link>
          <Link className="link">Atores</Link>
          <Link className="link">Diretores</Link>
          <Link className="link">Personagens</Link>
          <div onClick={showMenu} className="foto">
            <img onClick={showMenu} className="image" alt="icon" src={ImageIndis}></img>
          </div>

          {showMenuContext === true && (
           <ContextMenu >
           </ContextMenu>
          )}
        </div>
      </CompHeader>
    );
}