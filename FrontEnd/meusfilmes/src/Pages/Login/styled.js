import styled from "styled-components";

export const DivBox = styled.div`
  min-height: 50vh;
  width: 100%;
  display: flex;
  align-items: center;
  flex-direction: column;
  color: black;
  font-weight: bold;
  justify-content: space-evenly;


  .dv_inputs {
    display: flex;
    align-items: center;
    flex-direction: column;
    width: 100%;
  }

  label {
    width: 70%;
    margin-top: 10px;
  }

  h2 {
    font-weight: bold;
  }

  p {
    text-align: center;
    margin-top: 15px;
  }

  .link {
    text-decoration: none;
    cursor: pointer;
    color: var(--gray);
    &:hover {
      color: blue;
    }
  }

  @media (max-width: 600px) {
    color: white;
    .link {
      color: white;
    }
  }
`;
