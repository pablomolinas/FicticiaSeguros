import React, { useState, useContext, useEffect }  from "react";
import {useModal} from '../hooks/useModal';
import {Navigate} from "react-router-dom";
import UserContext from "../context/UserContext";
import {Container, Row, Col, Table} from 'react-bootstrap';
import sweetAlert from "sweetalert";
import {getPersons, deletePerson} from '../api/api';
import PersonForm from "./PersonForm";

export default function Persons() {
    let {user} = useContext(UserContext);    
    const [data, setData] = useState([]);
    const [actionNew, setActionNew] = useState(true);
    const [isOpen, openModal, closeModal] = useModal();
    const [currentPerson, setcurrentPerson] = useState({
        id: 0,
        dni: "",
        firstName: "",
        lastName: "",
        age: 0,
        gender: "",
        enable: true,
        drive: false,
        glasses: false,
        diabetic: false,
        diseases: []
      });    

    useEffect( async () => setData(await getPersons()), []);
            
    if(!user) return <Navigate to="/login" />    

    const updatePersons = () => {
        (async () => {
            setData(await getPersons());
        })();
    }

    const editPerson = (person) => {
        setcurrentPerson(person);
        setActionNew(false);
        openModal();        
    }

    const newPerson = () => {
        setActionNew(true);
        openModal();
    }
    
    const delPerson = (person) => {
        
        (async () => {
            var confirm = await sweetAlert({
                title: `¿Seguro que desea eliminar a ${person.lastName} ${person.firstName}?`,
                text: "",
                icon: "warning",
                buttons: true,
                dangerMode: true,
              });

            if(confirm){
                await deletePerson(person);
                setData(data.filter(p => p.id !== person.id));  
            }
        })();       
    }
    

    return(                
        <Container className="mt-5">
            <Row>
                <Col md="12" className="my-2">                    
                    <button className="btn btn-success me-auto" onClick={() => newPerson()} title="Registrar nueva persona">Nueva persona</button>                    
                </Col>
                <Col sm={12} md={12} lg xl xxl>
                    <Table striped bordered hover>
                        <thead>
                        <tr>
                            <th>#</th>
                            <th className="text-start">Nombre</th>
                            <th className="text-start">Edad</th>
                            <th>Accion</th>
                        </tr>
                        </thead>
                        <tbody className="text-start">
                        {data.map(p => (
                            <tr key={p.id}>
                            <td className="text-center">{p.id}</td>
                            <td>{p.lastName}, {p.firstName}</td>
                            <td>{p.age}</td>
                            <td className="text-center">
                                <button className="btn btn-primary me-2" title="Editar item" onClick={() => editPerson(p)}>Editar</button>
                                <button className="btn btn-danger" title="Eliminar item" onClick={() => delPerson(p)}>X</button>
                            </td>
                            </tr>
                        ))}
                        </tbody>
                    </Table>
                </Col>
            </Row>                       
            <PersonForm currentPerson={currentPerson} actionNew={actionNew} isOpen={isOpen} closeModal={closeModal} updatePersons={updatePersons}/>
        </Container>    
    )
}