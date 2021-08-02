import React, { useState } from "react";
import {DivMain} from "./styled"


export default function Procurar () {

    const [tipoBusca, setTipoBusca] = useState("Filmes");

    const buscar = () => {
        console.log(tipoBusca)
    }

    return (
      <DivMain>
        <select onChange={e => setTipoBusca(e.target.value)} className="form-select sele">
          <option>Filmes</option>
          <option>Atores</option>
          <option>Diretores</option>
          <option>Personagens</option>
        </select>

        <input
          style={{ borderRadius: "2px" }}
          placeholder="Procurar "
          className="form-control"
        />

        <button onClick={buscar} style={{ borderRadius: "2px" }} className="btn btn-warning">
          Pesquisar
        </button>
      </DivMain>
    );
}