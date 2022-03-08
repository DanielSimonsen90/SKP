import { Container, ContainerProps } from 'danholibraryrjs'
import { Item } from 'danhosaurportfolio-models'
import LinkItem from 'components/shared/navigation/LinkItem'

type Props = ContainerProps & {
    item: Item,
}

export default function SpareTimeItem({ item, ...props }: Props) {
    return (
        <article className='spare-time-item'>
            <LinkItem className='spare-time-item spare-time-item-top'
                title={item.name} hoverable={false} listElement={false}
                icon={`${item.name.toLowerCase().replaceAll(' ', '')}.png`} 
            />
            {item.description.map(sentence => <p key={sentence}>{sentence}</p>)}
        </article>
    )
}
