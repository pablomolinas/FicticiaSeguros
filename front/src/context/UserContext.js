import React from 'react';
import { createContext, useState, useEffect } from "react";

const UserContext = createContext();

const UserProvider = ({children}) => {
    const [user, setUser] = useState(false);
    const token = Boolean(localStorage.getItem("token"));

    useEffect(() => {
        if(!token){
            setUser(false);
        } else {
            setUser(true);
        }
    }, [user]);

    const data = {user, setUser}

    return <UserContext.Provider value={data}>{children}</UserContext.Provider>
}

export {UserProvider}
export default UserContext