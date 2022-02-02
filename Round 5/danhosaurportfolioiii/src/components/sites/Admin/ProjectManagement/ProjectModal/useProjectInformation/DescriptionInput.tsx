import { useTranslationObj } from "providers/LanguageProvider";
import { InputProps } from "../Label";

export type DescriptionInputProps = Omit<InputProps<string, 'text'>, 'type'>;
export default function DescriptionInput({ title, value, onChange }: DescriptionInputProps) {
    const data = useTranslationObj();
    const language = title.split(': ')[1];
    
    return (
        <label>
            <p>{title}</p>
            <textarea id={`project-description-${value}`} required={true}
                value={value} lang={data[language]['country-code']}
                onChange={e => onChange(e.currentTarget.value)}
                onKeyDown={e => { 
                    if (e.key === 'Enter') { 
                        e.stopPropagation();
                        // onChange(value + '\n');
                    }
                }}
            />
        </label>
    )
}