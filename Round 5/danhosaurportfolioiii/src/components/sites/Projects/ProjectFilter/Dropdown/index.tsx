import './Dropdown.scss'

type Props = {
    items: Array<string>
    onItemSelected: (item: string) => void
}

export default function Dropdown({ items, onItemSelected }: Props) {
    return (
        <ul className='dropdown'>
            {items.map(i => <li key={i} onClick={() => onItemSelected(i)}>{i}</li>)}
        </ul>
    );
}