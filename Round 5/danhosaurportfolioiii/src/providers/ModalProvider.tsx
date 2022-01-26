import { createContext, useContext, useMemo, useState } from 'react';
import { BaseProps, Component, Container, useStateStack, PushState, PopState, UseStateSetState } from 'danholibraryrjs';
import './Modal.scss';

export type ModalProps = {
    close(): void
}

type ModalShow = 'show' | 'hide';
type ModalContextType = [
    push: PushState<Component>, 
    pop: PopState, 
    isVisible: boolean
];
const ModalContext = createContext<ModalContextType>([s => 0, () => {}, false]);

type UseModalReturn = [
    visible: boolean,
    setVisible: (show: ModalShow, modal?: Component) => void,
    modal: Component,
    setModal: UseStateSetState<Component>
]
export function useModal(modalValue: Component): UseModalReturn {
    const [push, close, visible] = useContext(ModalContext);
    const [modalValueState, setModal] = useState(modalValue);
    const setVisible = (show: ModalShow, modal?: Component) => {
        if (modal && modal !== modalValueState) setModal(modal);
        if (show === 'show') push(modal ?? modalValueState);
        else close();
    }

    return [visible, setVisible, modalValueState, setModal]
}

type ModalWrapperProps = ModalProps & {
    component: Component
}

function ModalWrapper({ component, close }: ModalWrapperProps) {
    return (
        <Container className="modal" onClick={close}>
            <Container className='modal-content' onClick={e => e.stopPropagation()}>
                <p onClick={close} className='modal-exit'>❌</p>
                {component}
            </Container>
        </Container>
    )
}

export default function ModalProvider({ children }: BaseProps) {
    const { value, push: _push, pop, size } = useStateStack<Component>(null, { capacity: 5 });
    const isVisible = useMemo(() => size > 0, [size]);
    const push = (modalValue: Component) => _push(<ModalWrapper component={modalValue} close={pop} />);

    return (
        <ModalContext.Provider value={[push, pop, isVisible]}>
            {isVisible && value}
            {children}
        </ModalContext.Provider>
    );
}