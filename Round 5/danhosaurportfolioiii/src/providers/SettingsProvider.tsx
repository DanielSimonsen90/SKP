import { BaseProps, useLocalStorage } from "danholibraryrjs";
import { createContext, useCallback, useContext, useMemo } from "react"
import { SupportedLanguages } from "./LanguageProvider"

type Settings = {
    darkmode: boolean,
    language: SupportedLanguages,
    preferCards: boolean,
    animations: boolean,
}
type SettingsContext = [Settings, (type: ActionTypes, payload: Partial<Settings>) => Settings];
const SettingsContext = createContext<SettingsContext>([
    { darkmode: true, language: "English", preferCards: false, animations: true },
    () => ({ darkmode: true, language: "English", preferCards: false, animations: true })
]);

type ActionTypes = "set" | "reset";
function SettingsReducer(settings: Settings, type: ActionTypes, payload: Partial<Settings>) {
    switch (type) {
        case "set": return { ...settings, ...payload };
        case "reset": return { ...settings, ...payload };
        default: return settings;
    }
}

type UseSettingsReturn<Setting extends keyof Settings> = [Settings[Setting], (payload: Partial<Settings>[Setting]) => Settings[Setting]];
export function useSettings<Setting extends keyof Settings>(setting: Setting): UseSettingsReturn<Setting> {
    const [settings, dispatch] = useContext(SettingsContext);
    return [settings[setting], (payload: Partial<Settings>[Setting]) => dispatch("set", { [setting]: payload }) as any];
}

export default function SettingsProvider({ children }: BaseProps) {
    const defaultSettings = useMemo<Settings>(() => ({ darkmode: true, language: "English", preferCards: false, animations: true }), []);
    const [settings, setSettings] = useLocalStorage<"settings", Settings>("settings", defaultSettings);
    const dispatch = useCallback((type: ActionTypes, payload: Partial<Settings>) => {
        setSettings(s => SettingsReducer(s, type, payload));
        return settings;
    }, [settings]);

    return (
        <SettingsContext.Provider value={[settings, dispatch]}>
            {children}
        </SettingsContext.Provider>
    )
}