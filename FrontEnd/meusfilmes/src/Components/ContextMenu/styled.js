import { useContext } from "react";
import styled from "styled-components";
import { Context } from "../../Contexts/AuthContext";


export const MenuInfo = styled.div`

  
  width: 20vw;
  min-height: 40vh;
  display: flex;
  position: absolute;
  align-items: center;
  flex-direction: column;
  border-radius: 5px;
  background-color: var(--gray);
  z-index: 900;
  color: white;

  margin-left: 10%;
  justify-content: space-around;
  border: 1pt grey solid;

  .topo-info {
    height: 15vh;
    display: flex;
    width: auto;
    align-items: center;
    border-bottom: 1pt grey solid;
    width: 100%;
    padding-left: 10px;
  }

  .d-icon {
    width: 30%;
    display: flex;
    align-items: center;
    justify-content: center;
    width: 30%;
    height: 75%;
    border-radius: 220px;

  }

  .d-info {
    width: 70%;
    display: flex;
    justify-content: center;
    flex-direction: column;
    padding-left: 20px;
  }

  .middle {
    width: 100%;
    display: flex;
    padding-left: 10px;
    height: 17vh;
    padding-top: 10px;
    flex-direction: column;
    border-bottom: 1pt grey solid;
  }

  .link,
  p,
  h5 {
    margin-bottom: 0px;
  }

  .link, p {
    cursor: pointer;
  }

  Link:hover {
    color: var(--yellow);
  }

  p:hover {
    color: var(--yellow);
  }
  .email:hover{
      color: white;
      cursor: auto;
  }

  .bottom {
    padding-top: 20px;
    width: 100%;
    display: flex;
    height: 15vh;
    flex-direction: column;
    padding-left: 10px;
  }

  .icon {
    width: 100%;
    height: 100%;
    border-radius: 100px;
    cursor: pointer;
  }
`;
