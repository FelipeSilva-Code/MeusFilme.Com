import styled from "styled-components";

export const MainDiv = styled.div`
  width: 75%;

  height: 60vh;
  display: flex;
  align-items: center;
  flex-direction: column;

.div_bemvindo{
    width: auto;
    height: 50%;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
}

.div_sistema{
    width: 100%;
    height: 50%;
    display: flex;
}

.div_entrar, .div_cadastrar{
    width: 50%;
    height: 100%;
    text-align: center;
}

span, .link{
    color: var(--yellow);
    text-decoration: none;
}

 @media(max-width: 900px)
  {
    h3{
        font-size: 1.5em;
    }
  }

  @media(max-width: 500px)
  {

    width: 90%;
    h3{
        font-size: 1.3em;
    }

    .div_sistema{
        flex-direction: column;
        align-items: center;
    }

    .div_cadastrar{
        margin-top: 15px;
    }
  }
`;
