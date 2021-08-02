import React, { useContext } from "react";
import { Context } from "../../Contexts/AuthContext";
import Container from "../Container";
import Footer from "../Footer";
import HeaderOff from "../HeaderDeslogado";
import HeaderOn from "../HeaderLogado";

export default function PageDefault ({children}) {

    const {isAutenticado} = useContext(Context)
    const Header = isAutenticado ? HeaderOn : HeaderOff
    
    return(
        <>
            <Header/>

            <Container>
                {children}
            </Container>

            <Footer/>
        </>
    )
}