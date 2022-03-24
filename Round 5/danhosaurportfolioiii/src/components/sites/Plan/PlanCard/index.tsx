import { useMemo } from "react";
import { PlanItemProps, usePlanItemData, PlanRowProps } from "..";
import './PlanCard.scss';

type Props = PlanItemProps & Pick<PlanRowProps, 'planData'>

export default function PlanCard({ item, planData }: Props) {
    const {
        course, start, end, duration,
        courseType, dataCurrentOccupation 
    } = usePlanItemData(item);
    const visible = useMemo(() => planData.find(d => d.course === course), [planData, item]);

    return (
        <article className={`plan-card ${visible ? 'visible' : 'hidden'}`} data-course={courseType} {...{ 'data-current-occupation': dataCurrentOccupation }}>
            <h1>{course}</h1>
            <div className="start-end">
                <time dateTime={start.split('/').reverse().join('-')}>{start}</time>
                <time dateTime={end.split('/').reverse().join('-')}>{end}</time>
            </div>
            <h2>{duration}</h2>
        </article>
    );
}