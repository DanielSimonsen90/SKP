import { Item } from 'danhosaurportfolio-models'
import LinkItem from 'components/shared/navigation/LinkItem'

type Props = {
    item: Item,
}

export default function SpareTimeItem({ item }: Props) {
    return (
        <article className='spare-time-item' id={item.name.toLowerCase().replaceAll(' ', '')}>
            <LinkItem className='spare-time-item spare-time-item-top'
                title={item.name} hoverable={false} listElement={false}
                icon={`${item.name.toLowerCase().replaceAll(' ', '')}.png`} 
            />
            {item.description.map(sentence => <p key={sentence}>{sentence}</p>)}
        </article>
    )
}
