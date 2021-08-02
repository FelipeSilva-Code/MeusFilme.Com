import React from "react";
import {MyCard} from "./styled"
import ImageIndis from "../../Assets/Images/indisponivel.jpg";

export default function CardItem (props) {
    return (
      <MyCard>
        <div className="dv-image">
            <img className="img" alt="poster" src={ImageIndis}/>
        </div>

        <div className="infos">
            <div className="nome">
                {props.nome}
            </div>

            <div className="nota">
                {props.nota}
            </div>
        </div>
      </MyCard>
    );
}