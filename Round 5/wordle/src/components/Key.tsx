export type KeyStates = 'DEFAULT' | 'DISABLED' | 'INCORRECT' | 'INCLUDED' | 'CORRECT';
type Props = {
    value: string,
    state: KeyStates,
    onPress?: (value: string) => void
}

export default function Key({ value, state, onPress }: Props) {
    return (
        <div className='key' onClick={() => onPress?.(value)} data-state={state}>
            {value}
        </div>
    );
}