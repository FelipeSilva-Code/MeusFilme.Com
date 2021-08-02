import React from "react";
import { Link } from "react-router-dom";
import { CompHeader } from "./styled";

export default function HeaderOff () {
    return (
      <CompHeader>
        <Link className="link" to="/">
          <h2>MeusFilmes.Com</h2>
        </Link>
      </CompHeader>
    );
}