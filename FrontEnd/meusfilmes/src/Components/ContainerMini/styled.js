import styled from "styled-components";

export const Card = styled.div`
  min-height: 40vh;
  width: 40%;
  background-color: white;
  display: flex;
  align-items: center;
  flex-direction: column;
  justify-content: space-between;
  border-radius: 10px;
  padding-top: 25px;

  @media (max-width: 900px) {
    width: 60%;
  }

  @media (max-width: 600px) {
    width: 80%;
    color: white;
    background-color: transparent;
  }
`;
