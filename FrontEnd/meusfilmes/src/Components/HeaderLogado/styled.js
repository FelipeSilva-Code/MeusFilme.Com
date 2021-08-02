import styled from "styled-components";

export const CompHeader = styled.div`
  min-height: 10vh;
  width: 100%;
  background-color: var(--gray);
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding-right: 60px;
  padding-left: 60px;

  h2 {
    font-family: "Zen Tokyo Zoo", cursive;
    margin-top: 10px;
    color: var(--yellow);
  }

  .links-outrasTelas {
    display: flex;
    flex-direction: row;
    align-items: center;
    width: 40%;
    justify-content: space-between;
  }

  .link {
    text-decoration: none;
    color: white;

    &:hover {
      color: var(--yellow);
    }
  }

  .foto {
    width: 40px;
    height: 40px;
    border-radius: 100px;
  }

  .image {
    width: 100%;
    height: 100%;
    border-radius: 100px;
    cursor: pointer;
  }

  @media (max-width: 450px) {
    justify-content: center;

    h2 {
      margin-left: 0px;
    }
  }
`;
