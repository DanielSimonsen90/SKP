import { Container, ContainerProps } from 'danholibraryrjs'
import { Item } from 'danhosaurportfolio-models'
import LinkItem from 'components/shared/navigation/LinkItem'

type Props = ContainerProps & {
    item: Item,
}

export default function SpareTimeItem({ item, ...props }: Props) {
    return (
        <Container {...props} type="flex" className='spare-time-item'>
            {/* <Container type="flex" className="spare-time-item spare-time-item-top">
                <img src={`${item.name.toLowerCase().replaceAll(' ', '')}.png`} alt={`${item.name} logo`} />
                <h1>{item.name}</h1>
            </Container> */}
            <LinkItem className='spare-time-item spare-time-item-top'
                title={item.name} hoverable={false}
                icon={`${item.name.toLowerCase().replaceAll(' ', '')}.png`} 
            />
            <p>{item.description}</p>
        </Container>
    )
}
