import React from "react"
import MyCarousel from "../../Components/Carousel"
import PageDefault from "../../Components/PageDefault"
import Procurar from "../../Components/Procurar";
export default function Inicio () {
    return (
      <PageDefault>
        <Procurar></Procurar>

        <MyCarousel title="Últimos Lançamentos" />
        <MyCarousel title="Ação" />
        <MyCarousel title="Aventura" />
        <MyCarousel title="Biográfico" />
        <MyCarousel title="Comédia" />
        <MyCarousel title="Comédia dramática" />
        <MyCarousel title="Comédia romântica" />
        <MyCarousel title="Drama" />
        <MyCarousel title="Fantasia" />
        <MyCarousel title="Ficção científica" />
        <MyCarousel title="Histórico" />
        <MyCarousel title="Musical" />
        <MyCarousel title="Romance" />
        <MyCarousel title="Suspense" />
        <MyCarousel title="Terror" />
      </PageDefault>
    );
}