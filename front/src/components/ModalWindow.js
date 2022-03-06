import React from 'react';
import {Modal, ModalHeader, ModalBody} from 'react-bootstrap';

export default function ModalWindow({title, isOpen, closeModal, children}) {

    return(        
      <Modal show={isOpen} onHide={() => closeModal()} size="lg">
        <ModalHeader closeButton>{title}</ModalHeader>
        <ModalBody>
            {children}
        </ModalBody>        
      </Modal>
    )
}