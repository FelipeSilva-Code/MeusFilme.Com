import styled from 'styled-components'

export const CompHeader = styled.div`
  min-height: 10vh;
  width: 100%;
  background-color: var(--gray);
  display: flex;
  align-items: center;
  padding-left: 60px;

  h2 {
    font-family: "Zen Tokyo Zoo", cursive;
    margin-top: 10px;
    color: var(--yellow);
  }

 .link{
    text-decoration: none;
 }

@media(max-width: 450px)
{
    justify-content: center;
    padding-left: 0px;

     
  }
`;