import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import ContainerMini from "../../Components/ContainerMini";
import PageDefault from "../../Components/PageDefault";
import {DivBox} from "./styled"
import UsuarioService from "../../Services/UsuarioService";
import { useAlert } from "react-alert";

const usuarioService = new UsuarioService();

export default function Cadastrar() {

    const [nome, setNome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [permissao, setPermissao] = useState("Normal");

    const alert = useAlert();

    const history = useHistory();
    const cadastrar = async () => {
         try {
           const request = {
             "Nome": nome,
             "Email": email,
             "Senha": senha,
             "Permissao": permissao
           };
           
           await usuarioService.cadastrarUsuario(request);
           history.push("/login")

         } catch (e) {
            alert.error(e.response.data.mensagem)
         }
    }

    return (
      <PageDefault>
        <ContainerMini>
          <DivBox>
            <h2>Cadastro</h2>

            <div className="dv_inputs">
              <label>
                Nome
                <input
                  onChange={(e) => setNome(e.target.value)}
                  required
                  className="form-control"
                ></input>
              </label>

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

              <label>
                Permissão
                <select
                  onChange={(e) => setPermissao(e.target.value)}
                  className="form-select sele"
                >
                  <option selected>Normal</option>
                  <option>Adm</option>

                </select>
              </label>
            </div>

            <button
              style={{ fontWeight: "bold", marginTop: "20px" }}
              type="button"
              className="btn btn-warning"
              onClick={cadastrar}
            >
              Confirmar
            </button>

            <p>
              Já possui uma conta?
              <br />
              <Link className="link" to="/login">
                Entrar
              </Link>
            </p>
          </DivBox>
        </ContainerMini>
      </PageDefault>
    );
}