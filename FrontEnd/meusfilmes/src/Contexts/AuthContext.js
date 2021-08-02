import React, {createContext } from "react";

import useAuth from "./Hooks/useAuth";

const Context = createContext();

const AuthProvider = ({ children }) => {
    const { isAutenticado, usuario ,isLoading, logar, logout, isTerminouReq} = useAuth();
    
    return (
        <Context.Provider value={{isAutenticado, usuario ,isLoading, logar, logout, isTerminouReq}}>
            {children}
        </Context.Provider>
    )

}

export {Context, AuthProvider}