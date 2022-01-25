import { createContext, useContext, useMemo, useCallback, useState, useEffect } from 'react';
import { BaseProps, Component, Container, useStateStack, PushState, PopState } from 'danholibraryrjs';
import './Modal.scss';

type ModalShow = 'show' | 'hide';
type ModalContextType = [
    push: PushState<Component>, 
    pop: PopState, 
    size: number
];
const ModalContext = createContext<ModalContextType>([s => 0, () => {}, -1]);

export type ModalProps = {
    close(): void
}
export function useModal(modalValue: Component) {
    const [push, close, size] = useContext(ModalContext);

    console.log('useModal return', size);
    

    const modalWrapper = (
        <Container className="modal" onClick={() => {
            console.log('Outercontainer clicked');
            close()
        }}>
            <Container className='modal-content' onClick={e => e.stopPropagation()}>
                <p onClick={() => {
                    console.log('Exit clicked');
                    close()
                }} className='modal-exit'>❌</p>
                {modalValue}
            </Container>
        </Container>
    );

    return (show: ModalShow) => {
        if (show === 'show') push(modalWrapper);
        else close();
    }
}

export default function ModalProvider({ children }: BaseProps) {
    const { value, push, pop, size } = useStateStack<Component>(null, { capacity: 5 });

    console.log('ModalProvider, return', { stack: { value, size }});

    return (
        <ModalContext.Provider value={[push, pop, size]}>
            {value}
            {children}
        </ModalContext.Provider>
    );
}