import { Container } from 'danholibraryrjs';
import { PlanProps, PlanRowProps } from '../..';
import PlanCard from '..';
import './PlanCardContainer.scss';
import { useLocationCollection } from 'providers/MeProvider';
import { useMemo } from 'react';

export type PlanCardContainerProps = Pick<PlanProps, 'planData' | 'reverse'>

export default function PlanCardContainer({ planData, reverse }: PlanCardContainerProps) {
    const locationCollection = useLocationCollection();
    const items = useMemo(() => reverse ? [...locationCollection].reverse() : locationCollection, [reverse, locationCollection]);
    
    return (
        <Container className='plan-card-container'>
            {items.map((item, i) => <PlanCard planData={planData} item={item} key={i} />)}
        </Container>
    )
}