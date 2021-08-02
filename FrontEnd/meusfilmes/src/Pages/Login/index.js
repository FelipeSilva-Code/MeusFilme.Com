import React, { useContext, useState } from "react";
import { Link } from "react-router-dom";
import ContainerMini from "../../Components/ContainerMini";
import PageDefault from "../../Components/PageDefault";
import { Context } from "../../Contexts/AuthContext";
import {DivBox} from "./styled"

export default function Login() {

    const {logar} = useContext(Context);

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    return (
      <PageDefault>
        <ContainerMini>
          <DivBox>
            <h2>Entrar</h2>

            <div className="dv_inputs">
              <label>
                Email
                <input
                  onChange={(e) => setEmail(e.target.value)}
                  type="email"
                  required
                  className="form-control"
                ></input>
              </label>

              <label>
                Senha
                <input
                  onChange={(e) => setSenha(e.target.value)}
                  type="password"
                  required
                  className="form-control"
                ></input>
              </label>
            </div>

            <button
              style={{ fontWeight: "bold", marginTop: "20px" }}
              type="button"
              className="btn btn-warning"
              onClick={() => logar({ email, senha })}
            >
              Confirmar
            </button>

            <p>
              Não tem uma conta?
              <br />
              <Link className="link" to="/cadastro">
                Cadastrar-se
              </Link>
            </p>
          </DivBox>
        </ContainerMini>
      </PageDefault>
    );
}