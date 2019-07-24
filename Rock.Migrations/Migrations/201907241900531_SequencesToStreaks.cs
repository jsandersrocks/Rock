// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    ///
    /// </summary>
    public partial class SequencesToStreaks : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            TableChangesUp();
            PagesAndBlocksUp();
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            PagesAndBlocksDown();
            TableChangesDown();            
        }

        private void TableChangesUp()
        {
            RenameTable( name: "dbo.SequenceOccurrenceExclusion", newName: "StreakTypeExclusion" );
            RenameTable( name: "dbo.Sequence", newName: "StreakType" );
            RenameTable( name: "dbo.SequenceEnrollment", newName: "Streak" );
            RenameColumn( table: "dbo.Streak", name: "SequenceId", newName: "StreakTypeId" );
            RenameColumn( table: "dbo.StreakTypeExclusion", name: "SequenceId", newName: "StreakTypeId" );
            RenameIndex( table: "dbo.Streak", name: "IX_SequenceId", newName: "IX_StreakTypeId" );
            RenameIndex( table: "dbo.Streak", name: "IX_SequenceId_PersonAliasId", newName: "IX_StreakTypeId_PersonAliasId" );
            RenameIndex( table: "dbo.StreakTypeExclusion", name: "IX_SequenceId", newName: "IX_StreakTypeId" );
            AddColumn( "dbo.Streak", "InactiveDateTime", c => c.DateTime() );
            AddColumn( "dbo.Streak", "ExclusionMap", c => c.Binary() );
        }

        private void TableChangesDown()
        {
            DropColumn( "dbo.Streak", "ExclusionMap" );
            DropColumn( "dbo.Streak", "InactiveDateTime" );
            RenameIndex( table: "dbo.StreakTypeExclusion", name: "IX_StreakTypeId", newName: "IX_SequenceId" );
            RenameIndex( table: "dbo.Streak", name: "IX_StreakTypeId_PersonAliasId", newName: "IX_SequenceId_PersonAliasId" );
            RenameIndex( table: "dbo.Streak", name: "IX_StreakTypeId", newName: "IX_SequenceId" );
            RenameColumn( table: "dbo.StreakTypeExclusion", name: "StreakTypeId", newName: "SequenceId" );
            RenameColumn( table: "dbo.Streak", name: "StreakTypeId", newName: "SequenceId" );
            RenameTable( name: "dbo.Streak", newName: "SequenceEnrollment" );
            RenameTable( name: "dbo.StreakType", newName: "Sequence" );
            RenameTable( name: "dbo.StreakTypeExclusion", newName: "SequenceOccurrenceExclusion" );
        }

        private void PagesAndBlocksUp()
        {
            RockMigrationHelper.AddPage( true, "B0F4B33D-DD11-4CCC-B79D-9342831B8701", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Engagement", "", "A4360707-5163-497F-BBFF-E0EA1CE76946", "" ); // Site:Rock RMS
            RockMigrationHelper.UpdateBlockType( "Assessment Type Detail", "Displays the details of the given Assessment Type for editing.", "~/Blocks/Assessments/AssessmentTypeDetail.ascx", "Assessments", "0A710794-96D7-47DA-AA09-96E409410217" );
            RockMigrationHelper.UpdateBlockType( "Assessment Type List", "Shows a list of all Assessment Types.", "~/Blocks/Assessments/AssessmentTypeList.ascx", "Assessments", "64E61C8D-F9AE-4237-A1E5-F996E45FB689" );
            RockMigrationHelper.UpdateBlockType( "Connection Status Changes", "Shows changes of Connection Status for people within a specific period.", "~/Blocks/Crm/ConnectionStatusChangeReport.ascx", "Connection", "10E13A18-4EC0-4FDC-A829-579FA2F10F48" );
            RockMigrationHelper.UpdateBlockType( "Streak Detail", "Displays the details of the given streak for editing.", "~/Blocks/Streaks/StreakDetail.ascx", "Streaks", "D6D3358F-215A-4B54-9239-29D547CB96C8" );
            RockMigrationHelper.UpdateBlockType( "Streak List", "Lists all the people enrolled in a streak type.", "~/Blocks/Streaks/StreakList.ascx", "Streaks", "B0CC4D4D-B859-4F3D-BEDE-6C458ABA2E74" );
            RockMigrationHelper.UpdateBlockType( "Streak Map Editor", "Allows editing a streak occurrence, engagement, or exclusion map.", "~/Blocks/Streaks/StreakMapEditor.ascx", "Streaks", "2E218E92-0EB6-4CB2-A831-C1E1CBF96405" );
            RockMigrationHelper.UpdateBlockType( "Streak Type Detail", "Displays the details of the given Streak Type for editing.", "~/Blocks/Streaks/StreakTypeDetail.ascx", "Streaks", "C03FF7FB-2DB4-4765-8C43-98A2B5CB3424" );
            RockMigrationHelper.UpdateBlockType( "Streak Type Exclusion Detail", "Displays the details of the given Exclusion for editing.", "~/Blocks/Streaks/StreakTypeExclusionDetail.ascx", "Streaks", "0B4D183D-4EAA-4B3C-83DF-E5DB34FBC43D" );
            RockMigrationHelper.UpdateBlockType( "Streak Type Exclusion List", "Lists all the exclusions for a streak type.", "~/Blocks/Streaks/StreakTypeExclusionList.ascx", "Streaks", "CBA05162-EE6A-4B47-AD84-EA8A8EFA4C2A" );
            RockMigrationHelper.UpdateBlockType( "Streak Type List", "Shows a list of all streak types.", "~/Blocks/Streaks/StreakTypeList.ascx", "Streaks", "77D10691-0D13-4DE7-A8CE-040DAA74478A" );
            // Add Block to Page: Sequences Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "F81097ED-3C96-45F2-A4F8-7D4D4F3D17F3".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "77D10691-0D13-4DE7-A8CE-040DAA74478A".AsGuid(), "Streak Type List", "Main", @"", @"", 0, "D6BFCFA2-F040-4348-9E44-200277DF66E8" );
            // Add Block to Page: Streak Type Detail Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "CA566B33-0265-45C5-B1B2-6FFA6D4743F4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "C03FF7FB-2DB4-4765-8C43-98A2B5CB3424".AsGuid(), "Streak Type Detail", "Main", @"", @"", 0, "67E15266-C6F4-4502-874E-70664D5B7739" );
            // Add Block to Page: Streak Type Detail Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "CA566B33-0265-45C5-B1B2-6FFA6D4743F4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "B0CC4D4D-B859-4F3D-BEDE-6C458ABA2E74".AsGuid(), "Streak List", "Main", @"", @"", 1, "BF59CB3C-9E3B-4E41-B148-308BEB8724AD" );
            // Add Block to Page: Map Editor Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "E7D5B636-5F44-46D3-AE9F-E2681ACC7039".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "2E218E92-0EB6-4CB2-A831-C1E1CBF96405".AsGuid(), "Streak Map Editor", "Main", @"", @"", 0, "870A2A56-44EA-4B4D-8623-EA95EE16166A" );
            // Add Block to Page: Exclusions Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "1EEDBA14-0EE1-43F7-BB8D-70455FD425E5".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "CBA05162-EE6A-4B47-AD84-EA8A8EFA4C2A".AsGuid(), "Streak Type Exclusion List", "Main", @"", @"", 1, "DD59E375-86CF-4558-B4A5-B1484760FAAF" );
            // Add Block to Page: Streak Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "488BE67C-EDA0-489E-8D80-8CC67F5854D4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "D6D3358F-215A-4B54-9239-29D547CB96C8".AsGuid(), "Streak Detail", "Main", @"", @"", 0, "9B56620C-D385-457F-943A-81F4905A59BC" );
            // Add Block to Page: Streak Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "488BE67C-EDA0-489E-8D80-8CC67F5854D4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "2E218E92-0EB6-4CB2-A831-C1E1CBF96405".AsGuid(), "Streak Map Editor", "Main", @"", @"", 1, "10212995-784A-471A-8851-345C20EC384C" );
            // Add Block to Page: Exclusion Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "68EF459F-5D23-4930-8EA8-80CDF986BB94".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "0B4D183D-4EAA-4B3C-83DF-E5DB34FBC43D".AsGuid(), "Streak Type Exclusion Detail", "Main", @"", @"", 2, "3D5859FF-2428-494A-A7CD-4B52DE8FC705" );
            // Add Block to Page: Exclusion Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "68EF459F-5D23-4930-8EA8-80CDF986BB94".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "2E218E92-0EB6-4CB2-A831-C1E1CBF96405".AsGuid(), "Streak Map Editor", "Main", @"", @"", 3, "CB791FEA-72C0-4182-814D-9892AD7B70A4" );
            // Add Block to Page: Engagement Site: Rock RMS
            RockMigrationHelper.AddBlock( true, "A4360707-5163-497F-BBFF-E0EA1CE76946".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "CACB9D1A-A820-4587-986A-D66A69EE9948".AsGuid(), "Page Menu", "Main", @"", @"", 0, "4CC80C99-9844-495C-B903-5600BB22579B" );
            // update block order for pages with new blocks if the page,zone has multiple blocks
            Sql( @"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '67E15266-C6F4-4502-874E-70664D5B7739'" );  // Page: Streak Type Detail,  Zone: Main,  Block: Streak Type Detail
            Sql( @"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '9B56620C-D385-457F-943A-81F4905A59BC'" );  // Page: Streak,  Zone: Main,  Block: Streak Detail
            Sql( @"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '10212995-784A-471A-8851-345C20EC384C'" );  // Page: Streak,  Zone: Main,  Block: Streak Map Editor
            Sql( @"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = 'BF59CB3C-9E3B-4E41-B148-308BEB8724AD'" );  // Page: Streak Type Detail,  Zone: Main,  Block: Streak List
            Sql( @"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '3D5859FF-2428-494A-A7CD-4B52DE8FC705'" );  // Page: Exclusion,  Zone: Main,  Block: Streak Type Exclusion Detail
            Sql( @"UPDATE [Block] SET [Order] = 3 WHERE [Guid] = 'CB791FEA-72C0-4182-814D-9892AD7B70A4'" );  // Page: Exclusion,  Zone: Main,  Block: Streak Map Editor
            // Attrib for BlockType: Content Channel Item List:Content Channel
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "D835A0EC-C8DB-483A-A37C-E8FB6E956C3D", "Content Channel", "ContentChannel", "Content Channel", @"The content channel to retrieve the items for.", 1, @"", "D9ACCEE0-1172-45CE-A06D-E51638C772B8" );
            // Attrib for BlockType: Content Channel Item List:Page Size
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Page Size", "PageSize", "Page Size", @"The number of items to send per page.", 2, @"50", "A944CB10-3C54-4DA6-8CD6-DCE42FC37EFF" );
            // Attrib for BlockType: Content Channel Item List:Include Following
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Include Following", "IncludeFollowing", "Include Following", @"Determines if following data should be sent along with the results.", 3, @"False", "013B301D-C008-4EC6-AE53-F5D4B7EE3A43" );
            // Attrib for BlockType: Content Channel Item List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"The page to redirect to when selecting an item.", 4, @"", "07F355AD-78B8-4563-95FE-12D36E916A16" );
            // Attrib for BlockType: Content Channel Item List:Field Settings
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Field Settings", "FieldSettings", "Field Settings", @"JSON object of the configured fields to show.", 5, @"", "A3021B21-AD85-439F-AFAD-3838518FF9CB" );
            // Attrib for BlockType: Content Channel Item List:List Data Template
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "List Data Template", "ListDataTemplate", "List Data Template", @"The XAML for the lists data template.", 0, @"<StackLayout HeightRequest=""50"" WidthRequest=""200"" Orientation=""Horizontal"" Padding=""0,5,0,5"">
    <Label Text=""{Binding [Content]}"" />
</StackLayout>", "E48D4868-2F82-4D9E-8D50-5F31E14E9CD1" );
            // Attrib for BlockType: Content Channel Item List:Cache Duration
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "30C54CA8-E472-4AB4-85E8-3683A4EEC963", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Cache Duration", "CacheDuration", "Cache Duration", @"The number of seconds the data should be cached on the client before it is requested from the server again. A value of 0 means always reload.", 1, @"86400", "D1EA9B53-A5D4-48EF-90A8-DEFE07A31A98" );
            // Attrib for BlockType: Mobile Content:Content
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "AF9B914D-6CDF-4A41-A631-3098184834F7", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Content", "Content", "Content", @"The XAML to use when rendering the block. <span class='tip tip-lava'></span>", 0, @"", "AFCAEA29-7057-4C80-B387-D923F66F8935" );
            // Attrib for BlockType: Mobile Content:Enabled Lava Commands
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "AF9B914D-6CDF-4A41-A631-3098184834F7", "4BD9088F-5CC6-89B1-45FC-A2AAFFC7CC0D", "Enabled Lava Commands", "EnabledLavaCommands", "Enabled Lava Commands", @"The Lava commands that should be enabled for this block, only affects Lava rendered on the server.", 1, @"", "0D061889-9E1A-40C8-85D1-C261114ED3E5" );
            // Attrib for BlockType: Mobile Content:Dynamic Content
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "AF9B914D-6CDF-4A41-A631-3098184834F7", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Dynamic Content", "DynamicContent", "Dynamic Content", @"If enabled then the client will download fresh content from the server every period of Cache Duration, otherwise the content will remain static.", 0, @"False", "ED93B660-0904-4BF7-A1F9-29EA98BCF171" );
            // Attrib for BlockType: Mobile Content:Cache Duration
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "AF9B914D-6CDF-4A41-A631-3098184834F7", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Cache Duration", "CacheDuration", "Cache Duration", @"The number of seconds the data should be cached on the client before it is requested from the server again. A value of 0 means always reload.", 1, @"86400", "B8357F23-98BA-4926-AA72-410164B3A11E" );
            // Attrib for BlockType: Mobile Content:Lava Render Location
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "AF9B914D-6CDF-4A41-A631-3098184834F7", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Lava Render Location", "LavaRenderLocation", "Lava Render Location", @"Specifies where to render the Lava", 2, @"On Server", "04BE851B-2B29-4306-BFAD-D0DEDE0FA092" );
            // Attrib for BlockType: Mobile Dynamic Content:Content
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78EB4311-7EC7-4F18-AC66-A82F6077248F", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Content", "Content", "Content", @"The XAML to use when rendering the block. <span class='tip tip-lava'></span>", 0, @"", "D61124BC-842D-44CC-B901-F2520AB69509" );
            // Attrib for BlockType: Mobile Dynamic Content:Enabled Lava Commands
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78EB4311-7EC7-4F18-AC66-A82F6077248F", "4BD9088F-5CC6-89B1-45FC-A2AAFFC7CC0D", "Enabled Lava Commands", "EnabledLavaCommands", "Enabled Lava Commands", @"The Lava commands that should be enabled for this block.", 1, @"", "7F70A221-D4DE-4F4D-A25A-3585AA651B6E" );
            // Attrib for BlockType: Mobile Dynamic Content:Initial Content
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78EB4311-7EC7-4F18-AC66-A82F6077248F", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Initial Content", "InitialContent", "Initial Content", @"If the initial content should be static or dynamic.", 2, @"Static", "3BDB15F9-9BFE-4B4D-801A-A55C7CE25EFA" );
            // Attrib for BlockType: Mobile Image:Image Url
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "48E40DAB-B459-4C05-B0E7-02C32B41D0E5", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Image Url", "ImageUrl", "Image Url", @"The URL to use for displaying the image. <span class='tip tip-lava'></span>", 0, @"", "C2DE6D2F-508F-4C61-B620-EC34FA91F484" );
            // Attrib for BlockType: Mobile Image:Dynamic Content
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "48E40DAB-B459-4C05-B0E7-02C32B41D0E5", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Dynamic Content", "DynamicContent", "Dynamic Content", @"If enabled then the client will download fresh content from the server every period of Cache Duration, otherwise the content will remain static.", 0, @"False", "377CAB07-5258-425A-BEAE-A17C23880453" );
            // Attrib for BlockType: Mobile Image:Cache Duration
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "48E40DAB-B459-4C05-B0E7-02C32B41D0E5", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Cache Duration", "CacheDuration", "Cache Duration", @"The number of seconds the data should be cached on the client before it is requested from the server again. A value of 0 means always reload.", 1, @"86400", "7AE1C8EB-AE75-42A6-B032-7E0D2AF30F77" );
            // Attrib for BlockType: Mobile Login:Registration Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "53EF98FB-E92B-4BB5-AD4B-E37F664B3AB7", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Registration Page", "RegistrationPage", "Registration Page", @"The page that will be used to register the user.", 0, @"", "7778686A-BCE5-447E-B8E2-4E8CF914F5D9" );
            // Attrib for BlockType: Mobile Login:Forgot Password Url
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "53EF98FB-E92B-4BB5-AD4B-E37F664B3AB7", "C0D0D7E2-C3B0-4004-ABEA-4BBFAD10D5D2", "Forgot Password Url", "ForgotPasswordUrl", "Forgot Password Url", @"The URL to link the user to when they have forgotton their password.", 1, @"", "A52AFE44-9D1D-4AAC-B345-A1B6BE7B74ED" );
            // Attrib for BlockType: Mobile Profile Details:Connection Status
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Connection Status", "ConnectionStatus", "Connection Status", @"The connection status to use for new individuals (default = 'Web Prospect'.)", 11, @"368DD475-242C-49C4-A42C-7278BE690CC2", "396C282A-C378-4A3D-B521-B2ADFC069DDA" );
            // Attrib for BlockType: Mobile Profile Details:Record Status
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Record Status", "RecordStatus", "Record Status", @"The record status to use for new individuals (default = 'Pending'.)", 12, @"283999EC-7346-42E3-B807-BCE9B2BABB49", "9681BC34-686A-453E-BC57-987673AD16E8" );
            // Attrib for BlockType: Mobile Profile Details:Birthdate Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Birthdate Show", "BirthDateShow", "Birthdate Show", @"Determines whether the birthdate field will be available for input.", 0, @"True", "A0D74AC5-0DAD-4714-88F4-C9F7D4D2402A" );
            // Attrib for BlockType: Mobile Profile Details:BirthDate Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "BirthDate Required", "BirthDateRequired", "BirthDate Required", @"Requires that a birthdate value be entered before allowing the user to register.", 1, @"True", "8C72E4F5-149A-4107-8E4E-E022AA986F40" );
            // Attrib for BlockType: Mobile Profile Details:Campus Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Campus Show", "CampusShow", "Campus Show", @"Determines whether the campus field will be available for input.", 2, @"True", "8DC0E87B-62DA-4CB8-AB63-A1AD63595387" );
            // Attrib for BlockType: Mobile Profile Details:Campus Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Campus Required", "CampusRequired", "Campus Required", @"Requires that a campus value be entered before allowing the user to register.", 3, @"True", "D2651BBB-9BEF-4987-B32D-8BFAB98B30EB" );
            // Attrib for BlockType: Mobile Profile Details:Email Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Email Show", "EmailShow", "Email Show", @"Determines whether the email field will be available for input.", 4, @"True", "6DA39B5B-70E1-4793-B9C7-FAC8D4461A2E" );
            // Attrib for BlockType: Mobile Profile Details:Email Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Email Required", "EmailRequired", "Email Required", @"Requires that a email value be entered before allowing the user to register.", 5, @"True", "8F7BEE49-61D5-46CA-AB68-4C2D024F71C7" );
            // Attrib for BlockType: Mobile Profile Details:Mobile Phone Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Mobile Phone Show", "MobilePhoneShow", "Mobile Phone Show", @"Determines whether the mobile phone field will be available for input.", 6, @"True", "8431B3FA-EB97-4FA8-979E-FAB866C38A0C" );
            // Attrib for BlockType: Mobile Profile Details:Mobile Phone Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Mobile Phone Required", "MobilePhoneRequired", "Mobile Phone Required", @"Requires that a mobile phone value be entered before allowing the user to register.", 7, @"True", "A24C6BC1-226D-4EFE-AE24-0F0F41DA6D4A" );
            // Attrib for BlockType: Mobile Profile Details:Address Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Address Show", "AddressShow", "Address Show", @"Determines whether the address field will be available for input.", 8, @"True", "6D119C08-1BC5-48CC-ACF3-596A659D44F0" );
            // Attrib for BlockType: Mobile Profile Details:Address Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "BCD90C46-4E5C-4065-BEBB-46A85399118E", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Address Required", "AddressRequired", "Address Required", @"Requires that a address value be entered before allowing the user to register.", 9, @"True", "A98BD96E-C42F-4F51-A3B6-2DEDDCDFB3DA" );
            // Attrib for BlockType: Mobile Register:Connection Status
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Connection Status", "ConnectionStatus", "Connection Status", @"The connection status to use for new individuals (default = 'Web Prospect'.)", 11, @"368DD475-242C-49C4-A42C-7278BE690CC2", "4789EFEA-B158-4B4C-8EEB-19BD34BF561E" );
            // Attrib for BlockType: Mobile Register:Record Status
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Record Status", "RecordStatus", "Record Status", @"The record status to use for new individuals (default = 'Pending'.)", 12, @"283999EC-7346-42E3-B807-BCE9B2BABB49", "A431816B-13B1-498F-9041-C20A2EA9BD66" );
            // Attrib for BlockType: Mobile Register:Birthdate Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Birthdate Show", "BirthDateShow", "Birthdate Show", @"Determines whether the birthdate field will be available for input.", 0, @"True", "7344E49C-D6D0-4F06-9014-0BB4E48C5B50" );
            // Attrib for BlockType: Mobile Register:BirthDate Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "BirthDate Required", "BirthDateRequired", "BirthDate Required", @"Requires that a birthdate value be entered before allowing the user to register.", 1, @"True", "21D14D25-9812-483E-81D0-5D8A72DA3CD1" );
            // Attrib for BlockType: Mobile Register:Campus Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Campus Show", "CampusShow", "Campus Show", @"Determines whether the campus field will be available for input.", 2, @"True", "29D7EF0C-86B6-4B14-992D-AAE3081269E6" );
            // Attrib for BlockType: Mobile Register:Campus Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Campus Required", "CampusRequired", "Campus Required", @"Requires that a campus value be entered before allowing the user to register.", 3, @"True", "1BA60059-6685-46B4-A7FB-6AE22B453C93" );
            // Attrib for BlockType: Mobile Register:Email Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Email Show", "EmailShow", "Email Show", @"Determines whether the email field will be available for input.", 4, @"True", "17816933-FA15-4EC5-9CEF-899D51FD89C6" );
            // Attrib for BlockType: Mobile Register:Email Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Email Required", "EmailRequired", "Email Required", @"Requires that a email value be entered before allowing the user to register.", 5, @"True", "FCB63041-2DDE-4BE7-9E54-DCF4ED6889D0" );
            // Attrib for BlockType: Mobile Register:Mobile Phone Show
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Mobile Phone Show", "MobilePhoneShow", "Mobile Phone Show", @"Determines whether the mobile phone field will be available for input.", 6, @"True", "C82DA478-B27C-4498-A0BF-DE16A9926116" );
            // Attrib for BlockType: Mobile Register:Mobile Phone Required
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Mobile Phone Required", "MobilePhoneRequired", "Mobile Phone Required", @"Requires that a mobile phone value be entered before allowing the user to register.", 7, @"True", "DED6AE32-8EAC-4B78-9ED0-510113F92042" );
            // Attrib for BlockType: Mobile Workflow Entry:Workflow Type
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "2721B540-3FB2-4149-A462-C2966CC3C2F2", "46A03F59-55D3-4ACE-ADD5-B4642225DD20", "Workflow Type", "WorkflowType", "Workflow Type", @"The type of workflow to launch when viewing this.", 0, @"", "DFFD2C52-16C3-420A-A619-14C17362F7F8" );
            // Attrib for BlockType: Mobile Workflow Entry:Completion Action
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "2721B540-3FB2-4149-A462-C2966CC3C2F2", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Completion Action", "CompletionAction", "Completion Action", @"What action to perform when there is nothing left for the user to do.", 1, @"0", "76734C03-0DDC-4EAF-AD2C-45AFE4ACF25C" );
            // Attrib for BlockType: Mobile Workflow Entry:Completion Xaml
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "2721B540-3FB2-4149-A462-C2966CC3C2F2", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Completion Xaml", "CompletionXaml", "Completion Xaml", @"The XAML markup that will be used if the Completion Action is set to Show Completion Xaml. <span class='tip tip-lava'></span>", 2, @"", "52D6F327-4884-462D-BC7D-6F9161584C1C" );
            // Attrib for BlockType: Mobile Workflow Entry:Enabled Lava Commands
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "2721B540-3FB2-4149-A462-C2966CC3C2F2", "4BD9088F-5CC6-89B1-45FC-A2AAFFC7CC0D", "Enabled Lava Commands", "EnabledLavaCommands", "Enabled Lava Commands", @"The Lava commands that should be enabled for this block.", 3, @"", "0A86CC06-9209-4F5D-8F2C-CFABC0C3783D" );
            // Attrib for BlockType: Mobile Workflow Entry:Redirect To Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "2721B540-3FB2-4149-A462-C2966CC3C2F2", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Redirect To Page", "RedirectToPage", "Redirect To Page", @"The page the user will be redirected to if the Completion Action is set to Redirect to Page.", 4, @"", "F204E2B8-BDC6-4B9D-82E4-7A5A7BAD54A8" );
            // Attrib for BlockType: Assessment Type List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "64E61C8D-F9AE-4237-A1E5-F996E45FB689", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 1, @"", "8BB5CD6A-23B4-4AEB-91AE-08B6D63ADA15" );
            // Attrib for BlockType: Connection Status Changes:Person Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "10E13A18-4EC0-4FDC-A829-579FA2F10F48", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Person Detail Page", "PersonDetailPage", "Person Detail Page", @"", 0, @"", "0A395E16-8EA0-460B-AFE2-7FC824E700C2" );
            // Attrib for BlockType: Streak List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "B0CC4D4D-B859-4F3D-BEDE-6C458ABA2E74", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 1, @"", "DDD4AC32-CF80-43B3-9FD7-9607392AC699" );
            // Attrib for BlockType: Streak List:Person Profile Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "B0CC4D4D-B859-4F3D-BEDE-6C458ABA2E74", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Person Profile Page", "PersonProfilePage", "Person Profile Page", @"Page used for viewing a person's profile. If set, a view profile button will show for each enrollment.", 2, @"", "2E647E41-46D8-44FA-834F-A89FC3F3A69A" );
            // Attrib for BlockType: Streak Type Detail:Exclusions Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "C03FF7FB-2DB4-4765-8C43-98A2B5CB3424", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Exclusions Page", "ExclusionsPage", "Exclusions Page", @"Page used for viewing a list of streak type exclusions.", 2, @"", "118C32C3-A553-433A-9C4C-AF7B5B30294F" );
            // Attrib for BlockType: Streak Type Detail:Map Editor Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "C03FF7FB-2DB4-4765-8C43-98A2B5CB3424", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Map Editor Page", "MapEditorPage", "Map Editor Page", @"Page used for editing the streak type map.", 1, @"", "278CC180-EABC-4783-A82F-51E536616DF4" );
            // Attrib for BlockType: Streak Type Exclusion List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "CBA05162-EE6A-4B47-AD84-EA8A8EFA4C2A", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 1, @"", "59952F11-4DD4-4CB3-ABBC-E310D2C1E71F" );
            // Attrib for BlockType: Streak Type List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "77D10691-0D13-4DE7-A8CE-040DAA74478A", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 1, @"", "E8FEFA78-FD01-4815-8033-89282342CCFE" );
            // Attrib for BlockType: Step Entry:Workflow Entry Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "8D78BC55-6E67-40AB-B453-994D69503838", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Workflow Entry Page", "WorkflowEntryPage", "Workflow Entry Page", @"Page used to launch a new workflow of the selected type.", 3, @"", "44C0AE99-AB93-405D-8236-9FF1832DB2B8" );
            // Attrib Value for Block:Page Menu, Attribute:Include Current Parameters Page: Engagement, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "4CC80C99-9844-495C-B903-5600BB22579B", "EEE71DDE-C6BC-489B-BAA5-1753E322F183", @"False" );
            // Attrib Value for Block:Page Menu, Attribute:Template Page: Engagement, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "4CC80C99-9844-495C-B903-5600BB22579B", "1322186A-862A-4CF1-B349-28ECB67229BA", @"{% include '~~/Assets/Lava/PageListAsBlocks.lava' %}" );
            // Attrib Value for Block:Page Menu, Attribute:Number of Levels Page: Engagement, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "4CC80C99-9844-495C-B903-5600BB22579B", "6C952052-BC79-41BA-8B88-AB8EA3E99648", @"3" );
            // Attrib Value for Block:Page Menu, Attribute:Include Current QueryString Page: Engagement, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "4CC80C99-9844-495C-B903-5600BB22579B", "E4CF237D-1D12-4C93-AFD7-78EB296C4B69", @"False" );
            // Attrib Value for Block:Page Menu, Attribute:Is Secondary Block Page: Engagement, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "4CC80C99-9844-495C-B903-5600BB22579B", "C80209A8-D9E0-4877-A8E3-1F7DBF64D4C2", @"False" );
            // Attrib Value for Block:Streak Type List, Attribute:Detail Page Page: Sequences, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "D6BFCFA2-F040-4348-9E44-200277DF66E8", "E8FEFA78-FD01-4815-8033-89282342CCFE", @"ca566b33-0265-45c5-b1b2-6ffa6d4743f4" );
            // Attrib Value for Block:Streak Type Detail, Attribute:Exclusions Page Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "67E15266-C6F4-4502-874E-70664D5B7739", "118C32C3-A553-433A-9C4C-AF7B5B30294F", @"1eedba14-0ee1-43f7-bb8d-70455fd425e5" );
            // Attrib Value for Block:Streak Type Detail, Attribute:Map Editor Page Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "67E15266-C6F4-4502-874E-70664D5B7739", "278CC180-EABC-4783-A82F-51E536616DF4", @"e7d5b636-5f44-46d3-ae9f-e2681acc7039" );
            // Attrib Value for Block:Streak List, Attribute:Detail Page Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "BF59CB3C-9E3B-4E41-B148-308BEB8724AD", "DDD4AC32-CF80-43B3-9FD7-9607392AC699", @"488be67c-eda0-489e-8d80-8cc67f5854d4" );
            // Attrib Value for Block:Streak List, Attribute:Person Profile Page Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "BF59CB3C-9E3B-4E41-B148-308BEB8724AD", "2E647E41-46D8-44FA-834F-A89FC3F3A69A", @"08dbd8a5-2c35-4146-b4a8-0f7652348b25,7e97823a-78a8-4e8e-a337-7a20f2da9e52" );
            // Attrib Value for Block:Streak List, Attribute:core.CustomGridEnableStickyHeaders Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "BF59CB3C-9E3B-4E41-B148-308BEB8724AD", "0A0F3F65-74D0-4DE9-8F41-369A62FAC58C", @"False" );
            // Attrib Value for Block:Streak Type Exclusion List, Attribute:Detail Page Page: Exclusions, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "DD59E375-86CF-4558-B4A5-B1484760FAAF", "59952F11-4DD4-4CB3-ABBC-E310D2C1E71F", @"68ef459f-5d23-4930-8ea8-80cdf986bb94" );
            RockMigrationHelper.UpdateFieldType( "Badge Types", "", "Rock", "Rock.Field.Types.BadgeTypesFieldType", "77B4A31D-8475-4B3F-A89B-7E1D0731A0F8" );
            RockMigrationHelper.UpdateFieldType( "Sequence", "", "Rock", "Rock.Field.Types.SequenceFieldType", "AD017BD4-06D2-4779-A565-AC51BC96D6DD" );
            RockMigrationHelper.UpdateFieldType( "Badges", "", "Rock", "Rock.Field.Types.BadgesFieldType", "31E04CAD-B7FA-4727-8D41-3B0E318EFFB5" );
            RockMigrationHelper.UpdateFieldType( "Streak Type", "", "Rock", "Rock.Field.Types.StreakTypeFieldType", "62701B65-5687-43D7-A1CD-74AD762496C6" );
        }

        private void PagesAndBlocksDown()
        {
            // Attrib for BlockType: Step Entry:Workflow Entry Page
            RockMigrationHelper.DeleteAttribute( "44C0AE99-AB93-405D-8236-9FF1832DB2B8" );
            // Attrib for BlockType: Streak Type List:Detail Page
            RockMigrationHelper.DeleteAttribute( "E8FEFA78-FD01-4815-8033-89282342CCFE" );
            // Attrib for BlockType: Streak Type Exclusion List:Detail Page
            RockMigrationHelper.DeleteAttribute( "59952F11-4DD4-4CB3-ABBC-E310D2C1E71F" );
            // Attrib for BlockType: Streak Type Detail:Map Editor Page
            RockMigrationHelper.DeleteAttribute( "278CC180-EABC-4783-A82F-51E536616DF4" );
            // Attrib for BlockType: Streak Type Detail:Exclusions Page
            RockMigrationHelper.DeleteAttribute( "118C32C3-A553-433A-9C4C-AF7B5B30294F" );
            // Attrib for BlockType: Streak List:Person Profile Page
            RockMigrationHelper.DeleteAttribute( "2E647E41-46D8-44FA-834F-A89FC3F3A69A" );
            // Attrib for BlockType: Streak List:Detail Page
            RockMigrationHelper.DeleteAttribute( "DDD4AC32-CF80-43B3-9FD7-9607392AC699" );
            // Attrib for BlockType: Connection Status Changes:Person Detail Page
            RockMigrationHelper.DeleteAttribute( "0A395E16-8EA0-460B-AFE2-7FC824E700C2" );
            // Attrib for BlockType: Assessment Type List:Detail Page
            RockMigrationHelper.DeleteAttribute( "8BB5CD6A-23B4-4AEB-91AE-08B6D63ADA15" );
            // Attrib for BlockType: Mobile Workflow Entry:Redirect To Page
            RockMigrationHelper.DeleteAttribute( "F204E2B8-BDC6-4B9D-82E4-7A5A7BAD54A8" );
            // Attrib for BlockType: Mobile Workflow Entry:Enabled Lava Commands
            RockMigrationHelper.DeleteAttribute( "0A86CC06-9209-4F5D-8F2C-CFABC0C3783D" );
            // Attrib for BlockType: Mobile Workflow Entry:Completion Xaml
            RockMigrationHelper.DeleteAttribute( "52D6F327-4884-462D-BC7D-6F9161584C1C" );
            // Attrib for BlockType: Mobile Workflow Entry:Completion Action
            RockMigrationHelper.DeleteAttribute( "76734C03-0DDC-4EAF-AD2C-45AFE4ACF25C" );
            // Attrib for BlockType: Mobile Workflow Entry:Workflow Type
            RockMigrationHelper.DeleteAttribute( "DFFD2C52-16C3-420A-A619-14C17362F7F8" );
            // Attrib for BlockType: Mobile Register:Mobile Phone Required
            RockMigrationHelper.DeleteAttribute( "DED6AE32-8EAC-4B78-9ED0-510113F92042" );
            // Attrib for BlockType: Mobile Register:Mobile Phone Show
            RockMigrationHelper.DeleteAttribute( "C82DA478-B27C-4498-A0BF-DE16A9926116" );
            // Attrib for BlockType: Mobile Register:Email Required
            RockMigrationHelper.DeleteAttribute( "FCB63041-2DDE-4BE7-9E54-DCF4ED6889D0" );
            // Attrib for BlockType: Mobile Register:Email Show
            RockMigrationHelper.DeleteAttribute( "17816933-FA15-4EC5-9CEF-899D51FD89C6" );
            // Attrib for BlockType: Mobile Register:Campus Required
            RockMigrationHelper.DeleteAttribute( "1BA60059-6685-46B4-A7FB-6AE22B453C93" );
            // Attrib for BlockType: Mobile Register:Campus Show
            RockMigrationHelper.DeleteAttribute( "29D7EF0C-86B6-4B14-992D-AAE3081269E6" );
            // Attrib for BlockType: Mobile Register:BirthDate Required
            RockMigrationHelper.DeleteAttribute( "21D14D25-9812-483E-81D0-5D8A72DA3CD1" );
            // Attrib for BlockType: Mobile Register:Birthdate Show
            RockMigrationHelper.DeleteAttribute( "7344E49C-D6D0-4F06-9014-0BB4E48C5B50" );
            // Attrib for BlockType: Mobile Register:Record Status
            RockMigrationHelper.DeleteAttribute( "A431816B-13B1-498F-9041-C20A2EA9BD66" );
            // Attrib for BlockType: Mobile Register:Connection Status
            RockMigrationHelper.DeleteAttribute( "4789EFEA-B158-4B4C-8EEB-19BD34BF561E" );
            // Attrib for BlockType: Mobile Profile Details:Address Required
            RockMigrationHelper.DeleteAttribute( "A98BD96E-C42F-4F51-A3B6-2DEDDCDFB3DA" );
            // Attrib for BlockType: Mobile Profile Details:Address Show
            RockMigrationHelper.DeleteAttribute( "6D119C08-1BC5-48CC-ACF3-596A659D44F0" );
            // Attrib for BlockType: Mobile Profile Details:Mobile Phone Required
            RockMigrationHelper.DeleteAttribute( "A24C6BC1-226D-4EFE-AE24-0F0F41DA6D4A" );
            // Attrib for BlockType: Mobile Profile Details:Mobile Phone Show
            RockMigrationHelper.DeleteAttribute( "8431B3FA-EB97-4FA8-979E-FAB866C38A0C" );
            // Attrib for BlockType: Mobile Profile Details:Email Required
            RockMigrationHelper.DeleteAttribute( "8F7BEE49-61D5-46CA-AB68-4C2D024F71C7" );
            // Attrib for BlockType: Mobile Profile Details:Email Show
            RockMigrationHelper.DeleteAttribute( "6DA39B5B-70E1-4793-B9C7-FAC8D4461A2E" );
            // Attrib for BlockType: Mobile Profile Details:Campus Required
            RockMigrationHelper.DeleteAttribute( "D2651BBB-9BEF-4987-B32D-8BFAB98B30EB" );
            // Attrib for BlockType: Mobile Profile Details:Campus Show
            RockMigrationHelper.DeleteAttribute( "8DC0E87B-62DA-4CB8-AB63-A1AD63595387" );
            // Attrib for BlockType: Mobile Profile Details:BirthDate Required
            RockMigrationHelper.DeleteAttribute( "8C72E4F5-149A-4107-8E4E-E022AA986F40" );
            // Attrib for BlockType: Mobile Profile Details:Birthdate Show
            RockMigrationHelper.DeleteAttribute( "A0D74AC5-0DAD-4714-88F4-C9F7D4D2402A" );
            // Attrib for BlockType: Mobile Profile Details:Record Status
            RockMigrationHelper.DeleteAttribute( "9681BC34-686A-453E-BC57-987673AD16E8" );
            // Attrib for BlockType: Mobile Profile Details:Connection Status
            RockMigrationHelper.DeleteAttribute( "396C282A-C378-4A3D-B521-B2ADFC069DDA" );
            // Attrib for BlockType: Mobile Login:Forgot Password Url
            RockMigrationHelper.DeleteAttribute( "A52AFE44-9D1D-4AAC-B345-A1B6BE7B74ED" );
            // Attrib for BlockType: Mobile Login:Registration Page
            RockMigrationHelper.DeleteAttribute( "7778686A-BCE5-447E-B8E2-4E8CF914F5D9" );
            // Attrib for BlockType: Mobile Image:Cache Duration
            RockMigrationHelper.DeleteAttribute( "7AE1C8EB-AE75-42A6-B032-7E0D2AF30F77" );
            // Attrib for BlockType: Mobile Image:Dynamic Content
            RockMigrationHelper.DeleteAttribute( "377CAB07-5258-425A-BEAE-A17C23880453" );
            // Attrib for BlockType: Mobile Image:Image Url
            RockMigrationHelper.DeleteAttribute( "C2DE6D2F-508F-4C61-B620-EC34FA91F484" );
            // Attrib for BlockType: Mobile Dynamic Content:Initial Content
            RockMigrationHelper.DeleteAttribute( "3BDB15F9-9BFE-4B4D-801A-A55C7CE25EFA" );
            // Attrib for BlockType: Mobile Dynamic Content:Enabled Lava Commands
            RockMigrationHelper.DeleteAttribute( "7F70A221-D4DE-4F4D-A25A-3585AA651B6E" );
            // Attrib for BlockType: Mobile Dynamic Content:Content
            RockMigrationHelper.DeleteAttribute( "D61124BC-842D-44CC-B901-F2520AB69509" );
            // Attrib for BlockType: Mobile Content:Lava Render Location
            RockMigrationHelper.DeleteAttribute( "04BE851B-2B29-4306-BFAD-D0DEDE0FA092" );
            // Attrib for BlockType: Mobile Content:Cache Duration
            RockMigrationHelper.DeleteAttribute( "B8357F23-98BA-4926-AA72-410164B3A11E" );
            // Attrib for BlockType: Mobile Content:Dynamic Content
            RockMigrationHelper.DeleteAttribute( "ED93B660-0904-4BF7-A1F9-29EA98BCF171" );
            // Attrib for BlockType: Mobile Content:Enabled Lava Commands
            RockMigrationHelper.DeleteAttribute( "0D061889-9E1A-40C8-85D1-C261114ED3E5" );
            // Attrib for BlockType: Mobile Content:Content
            RockMigrationHelper.DeleteAttribute( "AFCAEA29-7057-4C80-B387-D923F66F8935" );
            // Attrib for BlockType: Content Channel Item List:Cache Duration
            RockMigrationHelper.DeleteAttribute( "D1EA9B53-A5D4-48EF-90A8-DEFE07A31A98" );
            // Attrib for BlockType: Content Channel Item List:List Data Template
            RockMigrationHelper.DeleteAttribute( "E48D4868-2F82-4D9E-8D50-5F31E14E9CD1" );
            // Attrib for BlockType: Content Channel Item List:Field Settings
            RockMigrationHelper.DeleteAttribute( "A3021B21-AD85-439F-AFAD-3838518FF9CB" );
            // Attrib for BlockType: Content Channel Item List:Detail Page
            RockMigrationHelper.DeleteAttribute( "07F355AD-78B8-4563-95FE-12D36E916A16" );
            // Attrib for BlockType: Content Channel Item List:Include Following
            RockMigrationHelper.DeleteAttribute( "013B301D-C008-4EC6-AE53-F5D4B7EE3A43" );
            // Attrib for BlockType: Content Channel Item List:Page Size
            RockMigrationHelper.DeleteAttribute( "A944CB10-3C54-4DA6-8CD6-DCE42FC37EFF" );
            // Attrib for BlockType: Content Channel Item List:Content Channel
            RockMigrationHelper.DeleteAttribute( "D9ACCEE0-1172-45CE-A06D-E51638C772B8" );
            // Remove Block: Streak Map Editor, from Page: Exclusion, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "CB791FEA-72C0-4182-814D-9892AD7B70A4" );
            // Remove Block: Streak Type Exclusion Detail, from Page: Exclusion, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "3D5859FF-2428-494A-A7CD-4B52DE8FC705" );
            // Remove Block: Streak Type Exclusion List, from Page: Exclusions, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "DD59E375-86CF-4558-B4A5-B1484760FAAF" );
            // Remove Block: Streak Map Editor, from Page: Map Editor, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "870A2A56-44EA-4B4D-8623-EA95EE16166A" );
            // Remove Block: Streak Map Editor, from Page: Streak, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "10212995-784A-471A-8851-345C20EC384C" );
            // Remove Block: Streak Detail, from Page: Streak, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "9B56620C-D385-457F-943A-81F4905A59BC" );
            // Remove Block: Streak List, from Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "BF59CB3C-9E3B-4E41-B148-308BEB8724AD" );
            // Remove Block: Streak Type Detail, from Page: Streak Type Detail, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "67E15266-C6F4-4502-874E-70664D5B7739" );
            // Remove Block: Streak Type List, from Page: Sequences, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "D6BFCFA2-F040-4348-9E44-200277DF66E8" );
            // Remove Block: Page Menu, from Page: Engagement, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "4CC80C99-9844-495C-B903-5600BB22579B" );
            RockMigrationHelper.DeleteBlockType( "77D10691-0D13-4DE7-A8CE-040DAA74478A" ); // Streak Type List
            RockMigrationHelper.DeleteBlockType( "CBA05162-EE6A-4B47-AD84-EA8A8EFA4C2A" ); // Streak Type Exclusion List
            RockMigrationHelper.DeleteBlockType( "0B4D183D-4EAA-4B3C-83DF-E5DB34FBC43D" ); // Streak Type Exclusion Detail
            RockMigrationHelper.DeleteBlockType( "C03FF7FB-2DB4-4765-8C43-98A2B5CB3424" ); // Streak Type Detail
            RockMigrationHelper.DeleteBlockType( "2E218E92-0EB6-4CB2-A831-C1E1CBF96405" ); // Streak Map Editor
            RockMigrationHelper.DeleteBlockType( "B0CC4D4D-B859-4F3D-BEDE-6C458ABA2E74" ); // Streak List
            RockMigrationHelper.DeleteBlockType( "D6D3358F-215A-4B54-9239-29D547CB96C8" ); // Streak Detail
            RockMigrationHelper.DeleteBlockType( "10E13A18-4EC0-4FDC-A829-579FA2F10F48" ); // Connection Status Changes
            RockMigrationHelper.DeleteBlockType( "64E61C8D-F9AE-4237-A1E5-F996E45FB689" ); // Assessment Type List
            RockMigrationHelper.DeleteBlockType( "0A710794-96D7-47DA-AA09-96E409410217" ); // Assessment Type Detail
            RockMigrationHelper.DeleteBlockType( "2721B540-3FB2-4149-A462-C2966CC3C2F2" ); // Mobile Workflow Entry
            RockMigrationHelper.DeleteBlockType( "78B8ED07-8F2C-410F-91FD-43BB30D53BB0" ); // Mobile Register
            RockMigrationHelper.DeleteBlockType( "BCD90C46-4E5C-4065-BEBB-46A85399118E" ); // Mobile Profile Details
            RockMigrationHelper.DeleteBlockType( "53EF98FB-E92B-4BB5-AD4B-E37F664B3AB7" ); // Mobile Login
            RockMigrationHelper.DeleteBlockType( "48E40DAB-B459-4C05-B0E7-02C32B41D0E5" ); // Mobile Image
            RockMigrationHelper.DeleteBlockType( "78EB4311-7EC7-4F18-AC66-A82F6077248F" ); // Mobile Dynamic Content
            RockMigrationHelper.DeleteBlockType( "AF9B914D-6CDF-4A41-A631-3098184834F7" ); // Mobile Content
            RockMigrationHelper.DeleteBlockType( "30C54CA8-E472-4AB4-85E8-3683A4EEC963" ); // Content Channel Item List
            RockMigrationHelper.DeletePage( "A4360707-5163-497F-BBFF-E0EA1CE76946" ); //  Page: Engagement, Layout: Full Width, Site: Rock RMS
        }
    }
}
