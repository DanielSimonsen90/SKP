import Key, { KeyStates } from './Key';

type Props = {
    keys: Map<string, KeyStates>
}

export default function Board({ keys }: Props) {
    return (
        <div className='board'>
            {keys.array().map(([key, state]) => <Key key={key} value={key} state={state} />)}
        </div>
    );
}