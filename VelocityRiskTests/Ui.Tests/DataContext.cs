using System.Collections.Generic;
using Ui.Tests.PersistenceModels;

namespace Ui.Tests
{
    public class DataContext
    {
        public static List<MenuItem> LoadMenuItems()
        {
            return
                new List<MenuItem>
                {
                    new MenuItem {Id = 1, Name = "Agents", Link = "https://velocityrisk.com/for-agents/"},
                    new MenuItem {Id = 2, Name = "Homeowners", Link = "https://velocityrisk.com/for-homeowners/"},
                    new MenuItem {Id = 3, Name = "Large Commercial", Link = "https://velocityrisk.com/for-businesses/large_business/"},
                    new MenuItem {Id = 4, Name = "Small Commercial", Link = "https://velocityrisk.com/small_business/"},
                    new MenuItem {Id = 5, Name = "Claims", Link = "https://velocityrisk.com/claims/"},
                    new MenuItem {Id = 6, Name = "Manage Your Policy", Link = "https://portal.velocityrisk.com/Login.aspx?ReturnUrl=%2f"},
                    new MenuItem {Id = 7, Name = "Make a Payment", Link = "https://portal.icheckgateway.com/Velocity/"},
                    new MenuItem {Id = 8, Name = "Notes and News", Link = "https://velocityrisk.com/news-and-notes/"}
                };
        }

        public static List<PanelItem> LoadPanelItems()
        {
            return
                new List<PanelItem>
            {
                new PanelItem {Id = 1, Title = "File a claim", Content =
@"If you’d like to quickly and conveniently report a claim, we can help:

Call us 24/7 at 844­-VRU-­CLMS (844-­878-­2567),
Reach out to your agent, or
File a claim online using the appropriate option below:

For homeowners, click here and use client access code vel6475.

For small commercial, click here and use client access code vel6942 or email your claim to smallbusiness.claims@velocityrisk.com.

For large commercial, click here and use client access code vel6459 or email your claim to business.claims@velocityrisk.com."},
                new PanelItem {Id = 2, Title = "Questions on an existing claim?", Content =
@"For questions on existing claims, call 844-878-2567.

If you have documents you’d like to submit on an existing claim, please email the information to claimdocuments@velocityrisk.com. Be sure to include the entire claim number in the subject line and provide any additional details about the claim in the body of the email."},
                new PanelItem {Id = 3, Title = "Our claims process", Content =
@"Every claim is unique; however, all claims generally follow these three phases:

1. Contact and Claims Advancement

After reporting your claim, it will be assigned to one of our experienced claim professionals. This claim handler will guide you through the process and work with a team of other associated claim professionals to manage your claim promptly and accurately to conclusion. In this phase, you will be contacted by your claim professional and he/she will:

Fully explain the claims process
Schedule an inspection of your damaged property/business if needed
Determine and investigate the loss and applicable policy coverages and benefits
Explain our Velocity Direct Repair™ program
Work with you to coordinate any needed emergency repairs or mitigation efforts
Answer any questions you may have pertaining to your claim
Clarify the next step in the process

2. Evaluation

If an inspection of your property is needed, the claim professional will meet with you on location. They will:

Discuss your damages
Gather all the facts about your loss
Investigate the cause of loss
Take photos to document the damages
Evaluate your loss and/or complete an estimate
Possibly secure necessary samples for further evaluation

Our goal is to assess the cause of the loss, determine applicable coverages, and move the claim towards resolution. The claims professional should explain the next steps and any additional information that may be needed from you, giving you a window of time during which you will next hear back from him or her. In some cases, an inspection may not be necessary and the claim professional will explain how your claim will advance toward resolution.

3. Settlement and Conclusion

The claim professional should contact you within the agreed time period established at the inspection or last contact. In this phase, the claim professional will explain the application of policy coverages to any settlement, disclaimer or partial disclaimer. If there is a full or partial disclaimer or denial of coverage, we will provide you a letter setting forth the exact reason for such disclaimer, citing specific policy language to support that decision. If we are issuing a claims payment, we will do so promptly and fully explain the settlement and provide copies of any estimates used to evaluate your settlement. Any and all questions you may have should be answered during this settlement discussion.

We do realize that questions may arise after the claim settlement and we encourage you to visit the Frequently Asked Questions (FAQ) section found below or again contact your assigned claim professional."},
                new PanelItem {Id = 4, Title = "General FAQs", Content =
@"What does Velocity Claims Services offer?

Our Velocity Claims team is staffed with caring and helpful professionals, available 24/7 to answer your questions and help you through the claims process.

Who should I contact to report a loss?

You should let your insurance agent know, but to get the claims process moving quickly, call us at 1-844-VRU-CLMS (844-878-2567) or visit the File a Claim section on this page. One of our customer service professionals will ask you a few questions to get the information we need to start the claims process.

How long will it take to handle my claim?

Our goal is to handle every claim in a professional and efficient manner. Depending on the size of the loss and cooperation of other involved resources, handling times can vary accordingly. Our commitment to you is to advance your claim along as quickly as possible and to keep you well-informed each step of the way. You can help by ensuring that you have provided us with all relevant information related to your claim.

How do I know if my claim will be covered?

The Velocity claims representative assigned to your claim will explain your policy benefits/coverages to you and will address how each applies to your specific claim.

Will my premium increase if I file a claim?

It depends in part on the terms of your policy, how many claims you’ve filed in the past and insurance regulations in your state. We encourage you to contact your insurance agent who can discuss these questions with you.

Will my policy be cancelled if I file a claim?

Many factors go into this answer, such as: any prior claims history, any unsafe property conditions, and any unsafe behaviors that may result in or have resulted in loss, etc. We encourage you to reach out to your insurance agent if you have any concerns.

What is a deductible?

It is the first portion of a covered loss that, according to your policy, you have agreed to pay before Velocity Claims, LLC starts paying for the covered costs of the loss. For example, if you have a covered loss of $2,000 and your policy carries a $1,000 deductible, you will pay the first $1,000, and we will pay the remaining $1,000. In exchange for agreeing to pay a deductible, you pay lower policy premiums each year. Contact your insurance agent if you would like to consider other deductible options.

When do I pay my deductible? To whom do I pay it?

Your deductible will be subtracted from the amount of your loss before we deliver your settlement payment. You will likely pay the amount of your deductible directly to your contractor once repairs are completed.

What if I think the other party is filing a fraudulent claim?

If you feel that the other party is filing a fraudulent claim, please let us know. Your Velocity claims representative will investigate all aspects of the claim and will take appropriate action. In circumstances of possible fraud, your Velocity claims representative will report relevant information to the proper reporting agencies for appropriate action by the applicable authorities.

What if the other party sues me? What should I do?

If you receive a legal summons and/or complaint, call your Velocity claims representative immediately at 1-844-VRU CLMS (844-878-2567) and forward a copy of the summons and/or complaint, along with any other letters and documents you receive to the Velocity claims representative who is working with you on your claim. It is extremely important that you get this information to us as soon as you receive it, as prompt action is required pursuant to the law and any delay could prejudice your rights or the rights of Velocity."},
                new PanelItem {Id = 5, Title = "Property Claim FAQs", Content =
@"Can I choose who will do repairs to my property?

Yes. Your Velocity claims representative will work with your choice of vendor or contractor. We may offer and explain the benefits of our Velocity Direct Repair™ program as an option to you, however, it is always your choice which vendor or contractor you use.

Will repairs be done properly and workmanship guaranteed?

By choosing your own contractor/vendor, you manage their work and ensure that the repairs meet your standards. We do not make any warranties as to the quality or standard of contractors’ or vendors’ work.

Should I file a police report for a loss or theft?

We recommend filing a police report immediately any time you experience property theft or vandalism to your property.

What if I do not have all the information about my loss right now? Should I wait to file a claim?

No, we recommend that you file your claim as soon as possible after the loss. Later, if you come across additional information that would help your Velocity claims representative with the claim, provide the information to them at that point.

Do I need to hire a public adjuster?

If you have suffered a major loss, you may be contacted by a public adjuster. These are independent claims adjusters who are not associated with Velocity in any way and will charge you a fee for their services based on the total value of your claim or settlement amount. The fee is not a covered expense and you cannot seek reimbursement for that cost from Velocity. We are confident that your Velocity claims representative will investigate, evaluate, and settle your claim fairly and efficiently such that a public adjuster is not needed; however, the decision is yours to make.

What else can I do to prepare for my first meeting with a Velocity claims representative?

If you can, in the event that you sustain property damage to your residence or commercial building, prepare a room-by-room inventory of damages and lost property. If you have the information, or remember it, include manufacturer names, model numbers, and purchase dates.

Should I start making repairs before you inspect the damage?

We know you are eager to start putting your home back together, but it is best to wait until we have conducted our first on-site inspection. The most important immediate action is for you to protect your property from further damage. That way, we can identify all the damages, preparing the most comprehensive estimate based on your policy coverages.

How should I choose a contractor?

We suggest that you seek out contractors who have a proven track record in your area. To help select a reliable contractor there a several things you can do. You can:

Talk with friends, neighbors and relatives who have hired contractors
Get references from any contractor you interview and
Contact your local Better Business Bureau for information about the contractors you are considering

Note: Do not sign a contract until you have reviewed it carefully and have agreed to payment terms, and verify that the contractor has an active license in your state (in many cases you will be able to check the status of the contractor’s license right on your state’s website).

Will you handle this claim any differently because the damage to my property was caused by a catastrophe?

When a catastrophic event occurs, we know that a timely response is key to delivering an exceptional customer experience. Through our strategic partnerships, we are able to utilize a network of dedicated field investigators, loss experts, and repair partners to quickly and accurately investigate and resolve claims and get you on the road to recovery – as fast as possible.

What should my first step be after a catastrophe?

First, make sure everyone in your family is safe, and get medical care if anyone has been injured. Then, call us at 1-844-VRU CLMS (844-878-2567) or visit the File a Claim section on this page. Protect your property by sealing broken windows, putting tarps over cracks or openings in exterior walls or roof, and doing whatever else you can to prevent additional damage. Keep receipts for any materials you buy; those costs may be reimbursable.

How can I monitor the status of my claim?

Feel free to contact your Velocity claims representative when you need a status update. Let that person know how often, or at which points in the process, you would like to be updated, and we will be happy to assist.

What if I or my contractor finds additional damage following the estimate or once repairs are underway?

Contact your Velocity claims representative and report the additional damage; we will re-inspect and determine whether the damage is covered by your policy.

Why is my settlement check made payable to both me and my mortgage company? How do I get it endorsed so I can cash it to pay for repairs?

When you have a mortgage on your home, settlement checks typically are made payable to both you and your mortgagee, as required by the mortgagee. You will need to contact your mortgage company to find out how to obtain their endorsement on the check."},
                new PanelItem {Id = 6, Title = "Additional Resources", Content =
@"New resource has tips, public education materials for Texas cities & counties

The Texas Department of Insurance (TDI) created an online toolkit to help city and county officials protect residents from scam artists after a storm or disaster.

“It’s important to get information to storm victims fast,” said Texas Insurance Commissioner Kent Sullivan. “People want to start the repair and recovery process as quickly as possible. Good information helps consumers make good decisions.”

After a major storm, TDI sends a fraud team to the affected area to meet with local officials and explain steps they can take to protect victims from bad contractors and other scams. In addition, TDI sends consumer protection specialists to disaster areas to answer consumer questions and help them start the insurance claim process.

The new toolkit lists actions local officials can take to deter scams, such as requiring permits for out-of-town solicitors and contractors. The toolkit also has printable flyers in English and Spanish, sample social media posts, and links to other resources."}
            };
        }
    }
}
