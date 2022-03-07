import { useTranslate } from "providers/LanguageProvider";
import { useLocationCollection } from "providers/MeProvider";
import { useMemo } from "react";
import { PlanProps } from ".";
import PlanRow from "./PlanRow";

export default function PlanTable({ titles, planData, reverse }: PlanProps) {
    const translate = useTranslate();
    const locationCollection = useLocationCollection();
    const items = useMemo(() => reverse ? [...locationCollection].reverse() : locationCollection, [reverse, locationCollection]);


    return (
        <table>
            <thead>
                <tr>
                    {titles.map((key, i) => <th key={i}>{translate(key)}</th>)}
                </tr>
            </thead>
            <tbody>
                {items.map((item, i) => <PlanRow key={i} item={item} planData={planData} />)}
            </tbody>
        </table>
    );
}