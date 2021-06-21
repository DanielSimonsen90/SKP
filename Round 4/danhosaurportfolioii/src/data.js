import { LocationCollection, ScheduleItem, Item, ProjectCollection } from 'models'

const contact = {
    github: "DanielSimonsen90",
    phone: "20 95 61 77",
    email: "DanielSimonsen90@gmail.com"
};
  
const locationCollection = new LocationCollection([
    new ScheduleItem("Folkeskole", new Date(2007, 8, 8), new Date(2017, 6, 15)),
    new ScheduleItem("10. klasse", new Date(2017, 8, 8), new Date(2018, 6, 15)),
    new ScheduleItem("Grundforløb 1 & 2", new Date(2018, 8, 8), new Date(2019, 6, 28)),
    new ScheduleItem("Hovedforløb 1", new Date(2020, 1, 6), new Date(2020, 3, 13)),
    new ScheduleItem("Hovedforløb 2", new Date(2020, 8, 3), new Date(2020, 10, 9)),
    new ScheduleItem("Hovedforløb 3", new Date(2021, 4, 6), new Date(2021, 6, 18)),
    new ScheduleItem("Hovedforløb 4", new Date(2021, 10, 11), new Date(2021, 12, 17)),
    new ScheduleItem("Hovedforløb 5", new Date(2022, 9, 19), new Date(2022, 11, 25)),
    new ScheduleItem("Hovedforløb 6", new Date(2023, 11, 6), new Date(2023, 12, 8))
]);
  
const spareTime = [
    new Item("Discord", "Jeg bruger meget af min tid på Discord. Dette inkluderer min interesse for Discord bots, måden Discord er sat op på via css/html, og generelle permission handling."),
    new Item("FL Studio", "Jeg tilbringer nogle gange min fritid op at lave min egen musik, som jeg sætter på services som Spotify & SoundCloud."),
    new Item("Overwatch", "Som programmør er man naturligt interesseret i spil - Overwatch har jeg spillet i 1000 timer og elsker at spille det med mine venner."),
    new Item("Skolehjem", "Jeg bor på Aalborg Erhvervskollegium ved TECHCOLLEGE på Øster Uttrupvej")
];
  
const projects = new ProjectCollection(contact.github, [
  
]);

export { contact, locationCollection, spareTime, projects }