import { PlanItemProps, usePlanItemData } from "..";
import './PlanCard.scss';

export default function PlanCard({ item }: PlanItemProps) {
    const {
        course, start, end, duration,
        courseType, dataCurrentOccupation 
    } = usePlanItemData(item);

    return (
        <article className='plan-card' data-course={courseType} {...{ 'data-current-occupation': dataCurrentOccupation }}>
            <h1>{course}</h1>
            <div className="start-end">
                <p>{start}</p>
                <p>{end}</p>
            </div>
            <h2>{duration}</h2>
        </article>
    );
}