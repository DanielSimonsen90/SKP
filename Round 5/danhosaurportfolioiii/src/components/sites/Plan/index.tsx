import { useEffect, useMemo, useRef, useState } from 'react';

import { LocationCollection, ScheduleItem } from 'danhosaurportfolio-models';
import { Button, useAnimationReverse, useMediaQuery, useStateOnUpdate } from 'danholibraryrjs';
import { GetCSSProperty, Time } from 'danholibraryjs';

import { useLocationCollection, useMe } from 'providers/MeProvider';
import { useTranslate } from 'providers/LanguageProvider';

import { ButtonContainer } from 'components/shared/container/SpecificContainer';
import LinkItem from 'components/shared/navigation/LinkItem';

import Occupation from './Occupation';
import PlanTable from './PlanTable';
import PlanCardContainer from './PlanCard/PlanCardContainer';

import './Plan.scss'

type PlanStates = 'future' | 'full';
export type PlanProps = {
    titles: Array<string>,
    planData: Array<ScheduleItem>,
    reverse: boolean
}
export type PlanItemProps = {
    item: ScheduleItem
}
export type PlanRowProps = Pick<PlanProps, 'planData'>;

export function usePlanItemData(item: ScheduleItem) {
    const translate = useTranslate();
    const me = useMe();

    const { course } = item;
    const [start, end] = [item.start, item.end].map(date => date.toString());

    const isCurrentOccupation = useMemo(() => me.occupation === item.course, [me, item]);
    const courseType = useMemo(() => item.course === 'Grundforløb' ? item.course : item.course.substring(0, item.course.length - 2), [item])
    const duration = useMemo(() => {
        const format = (time: number, type: 'month' | 'day') => `${time} ${translate(`${type}${time > 1 ? 's' : ''}`).toLowerCase()}`
        return `${format(item.duration.months, 'month')} & ${format((item.duration.getTotalDays() % Time.avgMonth), 'day')}`
    }, [item]);

    return { 
        course, start, duration, end,
        isCurrentOccupation, courseType,
        dataCurrentOccupation: isCurrentOccupation ? isCurrentOccupation : null
    }
}

export default function Plan() {
    const locationCollection = useLocationCollection();
    const isTiny = useMediaQuery('600');
    const translate = useTranslate();
    const addReverse = useAnimationReverse('button:last-child', 'reverse');
    const animateReverse = useAnimationReverse('.reverse', 'animation-reverse', GetCSSProperty('--animation-time', 'number'));

    const [isReverse, setIsReverse] = useState(false);
    const [planState, setPlanState] = useState<PlanStates>('future');

    const titles = useMemo(() => ['course', 'start', 'end', 'duration'].map(title => translate(title)), []);
    const futurePlan = useMemo(() => {
        const result = new Array<ScheduleItem>();
        for (const item of locationCollection) {
            if (item.end.getTime() > Date.now())
                result.push(item)
        }
        return result;
    }, [locationCollection]);
    const planData = useMemo(() => {
        let data = planState === 'full' ? [...locationCollection] : [...futurePlan];
        return isReverse ? data.reverse() : data;
    }, [planState, isReverse]);

    const onChangeEducationPlanClicked = () => setPlanState(s => s === 'full' ? 'future' : 'full');
    const onChangeDirectionClicked = () => setIsReverse(v => {
        try { v ? animateReverse().then(el => el.classList.remove('reverse')) : addReverse(); }
        catch {}
        return !v;
    });

    return (
        <section id="plan-page">
            <header className='presentation'>
                <h1>{translate('educationPlanTitle')[planState]}</h1>
                <Occupation link={false} />
                <LinkItem className='click-me' listElement={false} newPage link="Uddannelsesplan.pdf" title={translate('viewEducationPlan')} />
            </header>
            <ButtonContainer style={{ boxShadow: 'unset' }}>
                <Button importance='secondary' onClick={onChangeEducationPlanClicked}>{translate('changeEducationPlanState')}</Button>
                <Button importance='secondary' onClick={onChangeDirectionClicked} iconName='arrow-down'>{translate('changeDirection')}</Button>
            </ButtonContainer>
            {isTiny ? 
                <PlanCardContainer reverse={isReverse} planData={planData} /> : 
                <PlanTable reverse={isReverse} titles={titles} planData={planData} />
            }
        </section>
    )
}
