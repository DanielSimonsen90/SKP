import { useEffect } from "react";
import { Button, UseStateSetState, useEnterEsc, Switch } from "danholibraryrjs";
import { ms } from "danholibraryjs";
import { ToggleModal, useModal } from "providers/ModalProvider";
import { useTranslate } from "providers/LanguageProvider";
import { useSettings } from "providers/SettingsProvider";
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
function YoureBlindModal({ setDarkMode, showModal }: YoureBlindProps) {
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

type ThemeToggleProps = {
    disableModal?: boolean
}

export default function ThemeToggle({ disableModal = false }: ThemeToggleProps) {
    const [isDark, setDarkMode] = useSettings("darkmode");
    const [showModal] = useModal(<></>);
    
    useEffect(() => {
        let timeout: NodeJS.Timeout = null;
        document.body.classList.toggle("light", !isDark);
        if (!isDark && !disableModal) timeout = setTimeout(() => {
           showModal("show", <YoureBlindModal setDarkMode={setDarkMode} showModal={showModal} />);
        }, ms('5s'))
        return () => clearTimeout(timeout);
    }, [isDark])

    return (
        <Switch vertical id="theme-toggle" 
            checked={isDark} onCheckChanged={setDarkMode} 
            icons={{ checked: "moon-o", unchecked: "sun-o" }} 
        />
    )
}