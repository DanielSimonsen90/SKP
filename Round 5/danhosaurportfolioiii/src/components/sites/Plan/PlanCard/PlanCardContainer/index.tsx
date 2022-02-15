import { Container } from 'danholibraryrjs';
import { PlanProps } from '../..';
import PlanCard from '..';
import './PlanCardContainer.scss';

export type PlanCardContainerProps = Omit<PlanProps, 'titles'>

export default function PlanCardContainer({ planData }: PlanCardContainerProps) {
    return (
        <Container className='plan-card-container'>
            {planData.map((item, i) => <PlanCard item={item} key={i} />)}
        </Container>
    )
}