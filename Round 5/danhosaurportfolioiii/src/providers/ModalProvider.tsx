import { createContext, useContext, useMemo, useState, useCallback } from 'react';
import Icon from 'react-fontawesome';
import { BaseProps, Component, Container, useStack, PopState, UseStateSetState, useAnimationReverse } from 'danholibraryrjs';
import { GetCSSProperty } from 'danholibraryjs';
import './Modal.scss';

export type ModalProps = {
    close(): void
}

type ModalShow = 'show' | 'hide';
type ModalContextType = [
    push: (state: Component, wrapContent: boolean) => number, 
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
export function useModal(modalValue: Component, wrapContent = true): UseModalReturn {
    const [push, close, visible] = useContext(ModalContext);
    const [modalValueState, setModal] = useState(modalValue);
    const setVisible = (show: ModalShow, modal?: Component) => {
        if (modal && modal !== modalValueState) setModal(modal);
        if (show === 'show') push(modal ?? modalValueState, wrapContent);
        else close();
    }

    return [visible, setVisible, modalValueState, setModal]
}

type ModalWrapperProps = ModalProps & {
    component: Component,
    wrapContent: boolean
}

function ModalWrapper({ component, close, wrapContent }: ModalWrapperProps) {
    const modalContent = (<>
        <Icon onClick={close} className='modal-exit' name='times' />
        {component}
    </>);

    return (
        <Container className={`modal${component.props.className ? ` ${component.props.className}` : ''}`} onClick={close}>
            {wrapContent ? (
                <Container className='modal-content' onClick={e => e.stopPropagation()}>
                    {modalContent}
                </Container>
            ) : modalContent}
        </Container>
    )
}

export default function ModalProvider({ children }: BaseProps) {
    const { value, push: _push, pop, size } = useStack<Component>(null, { capacity: 5 });
    const isVisible = useMemo(() => size > 0, [size]);
    const closeAnimation = useAnimationReverse('.modal', 'animation-reverse', GetCSSProperty('--animation-time', 'number'));
    const close = () => closeAnimation().then(pop);
    const push = (modalValue: Component, wrapContent: boolean) => _push(<ModalWrapper component={modalValue} close={close} wrapContent={wrapContent} />);

    return (
        <ModalContext.Provider value={[push, close, isVisible]}>
            {isVisible && value}
            {children}
        </ModalContext.Provider>
    );
}