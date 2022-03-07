import React, { useEffect, useState } from "react";
import {getDiseases, updatePerson, newPerson} from '../api/api';
import {Formik, Form, Field, ErrorMessage} from "formik";
import PersonFormModule from "./PersonForm.module.css";
import { CustomSelect } from './CustomSelect';
import {validationPersonForm} from '../helpers/validationPersonForm';
import { diseasesToSelectItems, SelectItemsToDiseases } from "../helpers/diseasesMapper";
import ModalWindow from './ModalWindow';

const personDefault = {
    id: 0,
    dni: "",
    firstName: "",
    lastName: "",
    age: 0,
    gender: "",
    drive: false,
    glasses: false,
    diabetic: false,
    enable: true,
    diseases: []
}

export default function PersonForm({actionNew, currentPerson, isOpen, closeModal, updatePersons}) {
    const [diseases, setDiseases] = useState([]);    
    
    useEffect(async () => {               
        setDiseases(diseasesToSelectItems( await getDiseases() ));
    }, []);

    /*useEffect(() => {
        var p = Object.assign({}, currentPerson);
        p.diseases = diseasesToSelectItems( currentPerson.diseases );        
    }, [currentPerson]);*/
      
    return (<>
        <ModalWindow title={actionNew ? "Nueva persona" : "Editar Persona"} isOpen={isOpen} closeModal={closeModal}>
        <Formik
            enableReinitialize
            initialValues = {actionNew ? personDefault : currentPerson}
            onSubmit={(values, actions) => {
                setTimeout(() => {                  
                  actions.setSubmitting(false);
                }, 1000);
                
                const mappedDiseases = SelectItemsToDiseases(values.diseases);
                values.diseases = mappedDiseases;         
                (async () => {
                    var result = false;
                    if(actionNew)
                    {                        
                        result = await newPerson(values)
                    }else{
                        result = await updatePerson(values);
                    }
                    
                    if(result){                          
                        updatePersons();
                        closeModal();
                    }
                })();

            }}
            validate = {(values) => {
                return validationPersonForm(values);
            }}>
            {( {errors} ) => (
                
                <Form>
                    <div className="row">
                        <div className="col mb-2">
                            <label className="form-label">Dni</label>
                            <Field 
                                type="text" 
                                className="form-control" 
                                name="dni"                                
                            />
                            <ErrorMessage name="dni" component={() => (<p className={`${PersonFormModule.error}`}>{errors.dni}</p>)}/>
                        </div>
                        <div className="col mb-2">
                            <label className="form-label">Id</label>
                            <Field 
                                type="number" 
                                className="form-control" 
                                name="id"
                                readOnly
                            />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col mb-2">
                            <label className="form-label">Nombre</label>
                            <Field 
                                type="text" 
                                className="form-control" 
                                name="firstName"                                
                            />
                            <ErrorMessage name="firstName" component={() => (<p className={`${PersonFormModule.error}`}>{errors.firstName}</p>)}/>                            
                        </div>
                        
                        <div className="col mb-2">                            
                            <label className="form-label">Apellido</label>
                            <Field 
                                type="text" 
                                className="form-control" 
                                name="lastName"
                            />
                            <ErrorMessage name="lastName" component={() => (<p className={`${PersonFormModule.error}`}>{errors.lastName}</p>)}/>                            
                        </div>
                        
                    </div>
                    <div className="row">
                        <div className="col mb-2">
                            <label className="form-label">Edad</label>
                            <Field 
                                type="number" 
                                className="form-control" 
                                name="age"
                            />
                            <ErrorMessage name="age" component={() => (<p className={`${PersonFormModule.error}`}>{errors.age}</p>)}/>                            
                        </div>
                        <div className="col mb-2">
                            <label className="form-label">Sexo</label>                            
                            <Field className="form-select" name="gender" as="select">
                                <option value="">Selecciona una opcion</option>
                                <option value="HOMBRE">Hombre</option>
                                <option value="MUJER">Mujer</option>
                            </Field>
                            <ErrorMessage name="gender" component={() => (<p className={`${PersonFormModule.error}`}>{errors.gender}</p>)}/>
                        </div>
                    </div>
                    <div className="col mb-2">
                            <label className="form-label">Enfermedad/es preexistente/s</label>
                            <Field                              
                                name="diseases" 
                                as="select" 
                                isMulti={true}
                                component={CustomSelect}
                                options={diseases}
                            />  
                    </div>
                    <div className="row">
                        <div className="col-6 mb-2">                        
                            <div className="form-check">
                                <Field 
                                    className="form-check-input" 
                                    type="checkbox" 
                                    name="drive"
                                    id="drive"
                                />
                                <label className="form-check-label" htmlFor="drive">
                                    Conduce vehiculos
                                </label>
                            </div>
                            <div className="form-check">
                                <Field
                                    className="form-check-input"
                                    type="checkbox"
                                    name="glasses"
                                    id="glasses"
                                />
                                <label className="form-check-label" htmlFor="glasses">
                                    Utiliza lentes
                                </label>
                            </div>
                            <div className="form-check">
                                <Field 
                                    className="form-check-input" 
                                    type="checkbox" 
                                    name="diabetic"
                                    id="diabetic"
                                />
                                <label className="form-check-label" htmlFor="diabetic">
                                    Diabetes
                                </label>
                            </div>
                            <div className="form-check">
                                <Field 
                                    className="form-check-input" 
                                    type="checkbox" 
                                    name="enable"
                                    id="enable"
                                />
                                <label className="form-check-label" htmlFor="enable">
                                    Habilitado
                                </label>
                            </div>                                               
                        </div>
                        
                    </div>
                    <button type="submit" className="btn btn-primary">Guardar</button>
                    <button type="button" className="btn btn-secondary" onClick={() => closeModal()}>Cancelar</button>
                    
                </Form>
            )}

        </Formik>
        </ModalWindow>
    </>);
}