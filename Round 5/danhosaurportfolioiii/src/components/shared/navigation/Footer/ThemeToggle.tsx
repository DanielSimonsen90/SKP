import { useEffect } from "react";
import { Button, useDarkMode, UseStateSetState, useEnterEsc } from "danholibraryrjs";
import { ms } from "danholibraryjs";
import { ToggleModal, useModal } from "providers/ModalProvider";
import './ThemeToggle.scss';
import { useTranslate } from "providers/LanguageProvider";

type YoureBlindLanguage = {
    h1: string,
    h3: string,
    button: string
}

type YoureBlindProps = {
    showModal: ToggleModal,
    setDarkMode: UseStateSetState<boolean>
}
function YoureBlind({ setDarkMode, showModal }: YoureBlindProps) {
    const onConfirm = () => {
        showModal('hide');
        setDarkMode(true);
    }
    useEnterEsc({ onEnter: onConfirm });
    const translate = useTranslate<YoureBlindLanguage>()("youreBlind");

    return (
        <div id="youre-blind">
            <h1>{translate.h1}</h1>
            <h3>{translate.h3}</h3>
            <Button importance="primary" onClick={onConfirm} value={translate.button} />
        </div>
    )
}

export default function ThemeToggle() {
    const [isDark, setDarkMode] = useDarkMode();
    const [showModal] = useModal(<></>)
    
    useEffect(() => {
        document.body.classList.toggle("light", !isDark);

        let timeout: NodeJS.Timeout = null;
        if (!isDark) timeout = setTimeout(() => showModal("show", <YoureBlind setDarkMode={setDarkMode} showModal={showModal} />), ms('5s'))
        return () => timeout = null;
    }, [isDark])

    return (
        <input type="checkbox" checked={isDark} onChange={e => {
            setDarkMode(v => !v)
        }} />
    )
}