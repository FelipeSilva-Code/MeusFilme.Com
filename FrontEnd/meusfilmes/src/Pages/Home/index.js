import React from "react"
import { Link } from "react-router-dom"
import PageDefault from "../../Components/PageDefault"
import {MainDiv} from "./styled"

export default function Home () {
    return(
        <PageDefault>
            <MainDiv>
              
                <div className="div_bemvindo">
                    <h3>Bem-Vindo ao <span>MeusFilmes.com</span>
                    <br/>
                     Entre e tenha acesso as informações dos seus filmes, atores e  <br/>diretores favoritos</h3>
                </div>
                
                <div className="div_sistema">
                    
                    <div className="div_entrar">
                        <h3>Se você ja têm uma aqui é só
                            <br/>
                            <Link className="link" to="/login">Entrar</Link>
                        </h3>
                    </div>
                   
                    <div className="div_cadastrar">
                         <h3>Se você é novo por aqui basta
                            <br/>
                            <Link className="link" to="/cadastro">Cadastrar-se</Link>
                        </h3>
                    </div>
                </div>
            </MainDiv>
        </PageDefault>
    )
}