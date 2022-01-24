import { createContext, useContext, useMemo, useCallback, useState, useEffect } from 'react';
import { BaseProps, Component, Container, useStateStack, PushState, PopState } from 'danholibraryrjs';
import './Modal.scss';

type ModalShow = 'show' | 'hide';
type ModalContextType = [push: PushState<Component>, pop: PopState, size: number];
const ModalContext = createContext<ModalContextType>([s => 0, () => {}, -1]);

export type ModalProps = {
    close(): void
}
export function useModal(modalValue: Component) {
    const [push, pop, size] = useContext(ModalContext);
    const close = useCallback(() => {
        console.log('useModal setModal Container.onClick', size);
        return pop();
    }, [size]);

    const setModal = useCallback(() => {
        console.log('useModal, setModal', { size, modalValue });
        return push(v => (
            <Container className="modal" onClick={close}>
                <Container className='modal-content' onClick={e => e.stopPropagation()}>
                    <p onClick={close} className='modal-exit'>❌</p>
                    {/* {typeof modalValue === 'function' ? modalValue(v) : modalValue} */}
                    {modalValue}
                </Container>
            </Container>
        ))
    }, [modalValue, size]);

    return (show: ModalShow) => {
        if (show === 'show') setModal();
        else pop();
    }
}

export default function ModalProvider({ children }: BaseProps) {
    const { value, push, pop, size } = useStateStack<Component>(null, { capacity: 5 });
    const isVisible = useMemo(() => size > 0, [size]);
    const close = useCallback(() => pop(), [size]);

    useEffect(() => {
        console.log('ModalProvider, useEffect', {isVisible, stack: { value, size }});
    })

    return (
        <ModalContext.Provider value={[push, close, size]}>
            {isVisible && value}
            {children}
        </ModalContext.Provider>
    );
}