import React, { useState } from "react";
import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import CardItem from "../CardItem/index.js";
import {DivMain} from "./styled.js"

export default function MyCarousel (props) {

    const responsive = {
      superLargeDesktop: {
        // the naming can be any, depends on you.
        breakpoint: { max: 4000, min: 3000 },
        items: 7,
      },
      desktop: {
        breakpoint: { max: 3000, min: 1024 },
        items: 5,
      },
      tablet: {
        breakpoint: { max: 1024, min: 464 },
        items: 4,
      },
      mobile: {
        breakpoint: { max: 464, min: 0 },
        items: 3,
      },
    };

    const [filmes, setFilmes] = useState([]);

    return (
      <DivMain>
       
        <h4>{props.title}</h4>
       
        <Carousel
          swipeable={true}
          responsive={responsive}
          infinite={true}
          autoPlaySpeed={1000}
          keyBoardControl={true}
          removeArrowOnDeviceType={["tablet", "mobile"]}
        >
        
            <CardItem
            nome="Viuva Negra"
            nota={9.2}
            />

            
            <CardItem
            nome="Dupla Explosiva 2: E a Primeira-Dama do crime"
            nota={6.2}
            />

            <CardItem
            nome="Mortal Kombat"
            nota={6.1}
            />

            <CardItem
            nome="Ted 2"
            nota={6.3}
            />

            <CardItem
            nome="Quero matar meu chefe"
            nota={6.8}
            />

            <CardItem
            nome="Aqueles que me desejam a morte"
            nota={6.1}
            />

            <CardItem
            nome="Vizinho"
            nota={6.3}
            />

        </Carousel>
      
      </DivMain>
    );
}