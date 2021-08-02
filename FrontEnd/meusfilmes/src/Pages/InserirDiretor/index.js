import react from "react";
import { useHistory } from "react-router-dom";
import PageDefault from "../../Components/PageDefault";
import { MainDiv } from "./styled";

export default function InserirDiretor() {

  const history = useHistory();

  const voltar = () => {
      history.goBack()
  }
  return (
    <PageDefault>
      <MainDiv>
        <div className="d-title">
          <h2>Inserir Diretor</h2>
        </div>

        <div className="d-inputs">
          <label>
            Nome:
            <input className="form-control"></input>
          </label>

          <label>
            Descrição:
            <input className="form-control"></input>
          </label>

          <label>
            Nascimento:
            <input type="date" className="form-control"></input>
          </label>

          <label>
            País de origem:
            <select className="form-select sele">
              <option>Austrália</option>
              <option>Argentina</option>
              <option>Alemanha</option>
              <option>Brasil</option>
              <option>Canadá</option>
              <option>China</option>
              <option>Chile</option>
              <option>Coreia do Sul</option>
              <option>Estados Unidos</option>
              <option>Egito</option>
              <option>França</option>
              <option>Japão</option>
              <option>Noruega</option>
              <option>Suiça</option>
              <option>Índia</option>
              <option>Turquia</option>
              <option>Inglaterra</option>
              <option>Italia</option>
              <option>Suiça</option>
              <option>Suécia</option>
              <option>Portugal</option>
              <option>Holanda</option>
            </select>
          </label>

          <label>
            Foto:
            <input
              type="file"
              class="form-control"
              id="inputGroupFile02"
            ></input>
          </label>
        </div>

        <div className="d-buttons">
          <button onClick={voltar} className="btn btn-danger">Cancelar</button>

          <button className="btn btn-success">Confirmar</button>
        </div>
      </MainDiv>
    </PageDefault>
  );
}
