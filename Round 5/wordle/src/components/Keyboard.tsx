import Key, { KeyStates } from "./Key";

type Props = {
    keys: Map<string, KeyStates>
    onKeyPress(value: string): void
}

export default function Keyboard({ keys, onKeyPress }: Props) {
    return (
        <div className="keyboard">
            {keys.array().map(([key, state]) => <Key key={key} value={key} state={state} onPress={onKeyPress} />)}
        </div>
    );
}