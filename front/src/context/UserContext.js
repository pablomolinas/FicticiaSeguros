import React from 'react';
import { createContext, useState, useEffect } from "react";
import { useLocalStorage } from '../hooks/useLocalStorage';

const UserContext = createContext();

const UserProvider = ({children}) => {
    const [user, setUser] = useState(false);
    const [email, setEmail] = useLocalStorage("email", "");
    const [token, setToken] = useLocalStorage("token", "");    
    
    useEffect(() => {
        if(token){ // seria necesario validar si token expiró
            setUser(true);
        }
    }, []);

    const setLogout = () => {
        setEmail("");
        setToken("");
        setUser(false);
    }

    const setLogin = (email, token) => {
        setEmail(email);        
        
        setTimeout(() => {                              
            setToken(token);
            setUser(true);            
        }, 1000);
    }

    const data = {user, email, setLogin, setLogout}

    return <UserContext.Provider value={data}>{children}</UserContext.Provider>
}

export {UserProvider}
export default UserContext