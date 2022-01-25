import { useState } from "react";
import { TranslationObj } from "providers/LanguageProvider";
import { InputProps } from "../Label";

export function useDescription({ Dansk = [''], English = [''] }: TranslationObj = { Dansk: [''], English: [''] }) {
    const [dansk, setDansk] = useState<Array<string>>(Dansk);
    const [english, setEnglish] = useState<Array<string>>(English);

    return {
        dansk, setDansk,
        english, setEnglish
    }
}

export type DescriptionInputProps = Omit<InputProps<string, 'text'>, 'type'>;
export default function DescriptionInput({ title, value, onChange }: DescriptionInputProps) {
    return (
        <label>
            <p>{title}</p>
            <textarea id={`project-description-${value}`} 
                cols={30} rows={10}
                value={value}
                onChange={e => onChange(e.currentTarget.value)}
            />
        </label>
    )
}