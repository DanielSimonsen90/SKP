import { useEffect } from "react";
import { Button, useDarkMode, UseStateSetState, useEnterEsc, Switch } from "danholibraryrjs";
import { ms } from "danholibraryjs";
import { ToggleModal, useModal } from "providers/ModalProvider";
import { useTranslate } from "providers/LanguageProvider";
import './ThemeToggle.scss';

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
    const [showModal] = useModal(<></>);
    
    useEffect(() => {
        let timeout: NodeJS.Timeout = null;
        document.body.classList.toggle("light", !isDark);
        if (!isDark) timeout = setTimeout(() => {
           showModal("show", <YoureBlind setDarkMode={setDarkMode} showModal={showModal} />);
        }, ms('5s'))
        return () => clearTimeout(timeout);
    }, [isDark])

    return (
        <Switch checked={isDark} onCheckChanged={(v, e) => {
            console.log(v, e);
            setDarkMode(v);
        }} />
    )
}