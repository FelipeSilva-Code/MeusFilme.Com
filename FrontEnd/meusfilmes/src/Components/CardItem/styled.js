import styled from "styled-components";

export const MyCard = styled.div`

    height: 50vh;
    background-color: var(--gray);
    width: 17vw;
    cursor: pointer;
    border-radius: 10px;
 
  .dv-image {
    width: auto;
    height: 60%;
    border-radius: 10px;
  }

  .img{
      width: 100%;
      height: 100%;
      background-color: violet;
      border-radius: 10px;
  }
  .infos {
    display: flex;
    align-items: center;
    flex-direction: column;
    justify-content: space-around;
    height: 35%;
    border-radius: 25px;
  }

  .nome,
  .nota {
    text-align: center;
    width: 80%;
  }
`;
