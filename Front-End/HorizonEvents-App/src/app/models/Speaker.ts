import { SocialMedia } from "./SocialMedia";

export interface Speaker{
 id: number;
 name: string;
 smallResume: string;
 imageURL: string;
 phoneNumber: string;
 email: string;
 socialMedias: SocialMedia[];
 speakerEvents: Event[];
}
