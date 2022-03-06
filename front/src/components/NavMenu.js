import React from "react";
import { useContext }  from "react";
import {Navigate, useNavigate} from "react-router-dom";
import UserContext from "../context/UserContext";
import {Navbar, Container, Nav, NavDropdown} from 'react-bootstrap';

export default function NavMenu() {
    let {user} = useContext(UserContext);    
    const navigate = useNavigate();
    if(!user) return <Navigate to="/login" />

    const handleLogout = () => {
        navigate("/logout");        
    }    
    
    return(        
        <Navbar bg="dark" variant={"dark"} expand="lg" fixed="top">
        <Container>
            <Navbar.Brand href="#" onClick={() => <Navigate to="/login"/>}>Ficticia SA</Navbar.Brand>
            <Navbar.Toggle />
            <Navbar.Collapse className="justify-content-end">                
                <Nav className="ms-auto">                    
                    <NavDropdown title="UserEmail" id="collasible-nav-dropdown">
                        <NavDropdown.Item href="#" onClick={handleLogout} >Logout</NavDropdown.Item>                        
                    </NavDropdown>
                </Nav>
            </Navbar.Collapse>
        </Container>
        </Navbar>        
    )
}