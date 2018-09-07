﻿// <copyright>
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
    public partial class AddForeignIdIndex : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AlterColumn("dbo.AttendanceCode", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Attendance", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Campus", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PersonAlias", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Person", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.DefinedValue", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.DefinedType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Category", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.EntityType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FieldType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Group", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.SystemEmail", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.GroupLocation", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Location", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BinaryFile", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BinaryFileType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BinaryFileData", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Device", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Schedule", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.GroupType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.GroupTypeRole", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.GroupScheduleExclusion", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.GroupMember", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.DataView", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.DataViewFilter", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PhoneNumber", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserLogin", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.AttributeQualifier", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Attribute", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.AttributeValue", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.AuditDetail", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Audit", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Auth", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BenevolenceRequest", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BenevolenceResult", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Block", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.BlockType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Layout", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Page", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageContext", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageRoute", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Site", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.SiteDomain", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.CommunicationRecipientActivity", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.CommunicationRecipient", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Communication", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.CommunicationTemplate", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContentChannelItem", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContentChannel", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContentChannelType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.EntitySetItem", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.EntitySet", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ExceptionLog", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialAccount", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialBatch", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialTransaction", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialGateway", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialTransactionImage", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialTransactionRefund", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialScheduledTransaction", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialScheduledTransactionDetail", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialTransactionDetail", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialPersonBankAccount", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialPersonSavedAccount", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.FinancialPledge", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Following", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.History", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.HtmlContent", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.MetricCategory", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Metric", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.MetricValue", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Note", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.NoteType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageView", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PersonBadge", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PersonViewed", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PluginMigration", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PrayerRequest", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ReportField", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Report", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.RestAction", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.RestController", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ServiceJob", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.ServiceLog", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.TaggedItem", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Tag", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowActionFormAttribute", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowActionForm", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowAction", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowActionType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowActivityType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowType", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowActivity", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Workflow", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowLog", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.WorkflowTrigger", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.MergeTemplate", "ForeignId", c => c.String(maxLength: 100));
            AlterColumn("dbo.PersonDuplicate", "ForeignId", c => c.String(maxLength: 100));
            CreateIndex("dbo.AttendanceCode", "ForeignId");
            CreateIndex("dbo.Attendance", "ForeignId");
            CreateIndex("dbo.Campus", "ForeignId");
            CreateIndex("dbo.PersonAlias", "ForeignId");
            CreateIndex("dbo.Person", "ForeignId");
            CreateIndex("dbo.DefinedValue", "ForeignId");
            CreateIndex("dbo.DefinedType", "ForeignId");
            CreateIndex("dbo.Category", "ForeignId");
            CreateIndex("dbo.EntityType", "ForeignId");
            CreateIndex("dbo.FieldType", "ForeignId");
            CreateIndex("dbo.Group", "ForeignId");
            CreateIndex("dbo.SystemEmail", "ForeignId");
            CreateIndex("dbo.GroupLocation", "ForeignId");
            CreateIndex("dbo.Location", "ForeignId");
            CreateIndex("dbo.BinaryFile", "ForeignId");
            CreateIndex("dbo.BinaryFileType", "ForeignId");
            CreateIndex("dbo.BinaryFileData", "ForeignId");
            CreateIndex("dbo.Device", "ForeignId");
            CreateIndex("dbo.Schedule", "ForeignId");
            CreateIndex("dbo.GroupType", "ForeignId");
            CreateIndex("dbo.GroupTypeRole", "ForeignId");
            CreateIndex("dbo.GroupScheduleExclusion", "ForeignId");
            CreateIndex("dbo.GroupMember", "ForeignId");
            CreateIndex("dbo.DataView", "ForeignId");
            CreateIndex("dbo.DataViewFilter", "ForeignId");
            CreateIndex("dbo.PhoneNumber", "ForeignId");
            CreateIndex("dbo.UserLogin", "ForeignId");
            CreateIndex("dbo.AttributeQualifier", "ForeignId");
            CreateIndex("dbo.Attribute", "ForeignId");
            CreateIndex("dbo.AttributeValue", "ForeignId");
            CreateIndex("dbo.AuditDetail", "ForeignId");
            CreateIndex("dbo.Audit", "ForeignId");
            CreateIndex("dbo.Auth", "ForeignId");
            CreateIndex("dbo.BenevolenceRequest", "ForeignId");
            CreateIndex("dbo.BenevolenceResult", "ForeignId");
            CreateIndex("dbo.Block", "ForeignId");
            CreateIndex("dbo.BlockType", "ForeignId");
            CreateIndex("dbo.Layout", "ForeignId");
            CreateIndex("dbo.Page", "ForeignId");
            CreateIndex("dbo.PageContext", "ForeignId");
            CreateIndex("dbo.PageRoute", "ForeignId");
            CreateIndex("dbo.Site", "ForeignId");
            CreateIndex("dbo.SiteDomain", "ForeignId");
            CreateIndex("dbo.CommunicationRecipientActivity", "ForeignId");
            CreateIndex("dbo.CommunicationRecipient", "ForeignId");
            CreateIndex("dbo.Communication", "ForeignId");
            CreateIndex("dbo.CommunicationTemplate", "ForeignId");
            CreateIndex("dbo.ContentChannelItem", "ForeignId");
            CreateIndex("dbo.ContentChannel", "ForeignId");
            CreateIndex("dbo.ContentChannelType", "ForeignId");
            CreateIndex("dbo.EntitySetItem", "ForeignId");
            CreateIndex("dbo.EntitySet", "ForeignId");
            CreateIndex("dbo.ExceptionLog", "ForeignId");
            CreateIndex("dbo.FinancialAccount", "ForeignId");
            CreateIndex("dbo.FinancialBatch", "ForeignId");
            CreateIndex("dbo.FinancialTransaction", "ForeignId");
            CreateIndex("dbo.FinancialGateway", "ForeignId");
            CreateIndex("dbo.FinancialTransactionImage", "ForeignId");
            CreateIndex("dbo.FinancialTransactionRefund", "ForeignId");
            CreateIndex("dbo.FinancialScheduledTransaction", "ForeignId");
            CreateIndex("dbo.FinancialScheduledTransactionDetail", "ForeignId");
            CreateIndex("dbo.FinancialTransactionDetail", "ForeignId");
            CreateIndex("dbo.FinancialPersonBankAccount", "ForeignId");
            CreateIndex("dbo.FinancialPersonSavedAccount", "ForeignId");
            CreateIndex("dbo.FinancialPledge", "ForeignId");
            CreateIndex("dbo.Following", "ForeignId");
            CreateIndex("dbo.History", "ForeignId");
            CreateIndex("dbo.HtmlContent", "ForeignId");
            CreateIndex("dbo.MetricCategory", "ForeignId");
            CreateIndex("dbo.Metric", "ForeignId");
            CreateIndex("dbo.MetricValue", "ForeignId");
            CreateIndex("dbo.Note", "ForeignId");
            CreateIndex("dbo.NoteType", "ForeignId");
            CreateIndex("dbo.PageView", "ForeignId");
            CreateIndex("dbo.PersonBadge", "ForeignId");
            CreateIndex("dbo.PersonViewed", "ForeignId");
            CreateIndex("dbo.PluginMigration", "ForeignId");
            CreateIndex("dbo.PrayerRequest", "ForeignId");
            CreateIndex("dbo.ReportField", "ForeignId");
            CreateIndex("dbo.Report", "ForeignId");
            CreateIndex("dbo.RestAction", "ForeignId");
            CreateIndex("dbo.RestController", "ForeignId");
            CreateIndex("dbo.ServiceJob", "ForeignId");
            CreateIndex("dbo.ServiceLog", "ForeignId");
            CreateIndex("dbo.TaggedItem", "ForeignId");
            CreateIndex("dbo.Tag", "ForeignId");
            CreateIndex("dbo.WorkflowActionFormAttribute", "ForeignId");
            CreateIndex("dbo.WorkflowActionForm", "ForeignId");
            CreateIndex("dbo.WorkflowAction", "ForeignId");
            CreateIndex("dbo.WorkflowActionType", "ForeignId");
            CreateIndex("dbo.WorkflowActivityType", "ForeignId");
            CreateIndex("dbo.WorkflowType", "ForeignId");
            CreateIndex("dbo.WorkflowActivity", "ForeignId");
            CreateIndex("dbo.Workflow", "ForeignId");
            CreateIndex("dbo.WorkflowLog", "ForeignId");
            CreateIndex("dbo.WorkflowTrigger", "ForeignId");
            CreateIndex("dbo.MergeTemplate", "ForeignId");
            CreateIndex("dbo.PersonDuplicate", "ForeignId");
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.PersonDuplicate", new[] { "ForeignId" });
            DropIndex("dbo.MergeTemplate", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowTrigger", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowLog", new[] { "ForeignId" });
            DropIndex("dbo.Workflow", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowActivity", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowType", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowActivityType", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowActionType", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowAction", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowActionForm", new[] { "ForeignId" });
            DropIndex("dbo.WorkflowActionFormAttribute", new[] { "ForeignId" });
            DropIndex("dbo.Tag", new[] { "ForeignId" });
            DropIndex("dbo.TaggedItem", new[] { "ForeignId" });
            DropIndex("dbo.ServiceLog", new[] { "ForeignId" });
            DropIndex("dbo.ServiceJob", new[] { "ForeignId" });
            DropIndex("dbo.RestController", new[] { "ForeignId" });
            DropIndex("dbo.RestAction", new[] { "ForeignId" });
            DropIndex("dbo.Report", new[] { "ForeignId" });
            DropIndex("dbo.ReportField", new[] { "ForeignId" });
            DropIndex("dbo.PrayerRequest", new[] { "ForeignId" });
            DropIndex("dbo.PluginMigration", new[] { "ForeignId" });
            DropIndex("dbo.PersonViewed", new[] { "ForeignId" });
            DropIndex("dbo.PersonBadge", new[] { "ForeignId" });
            DropIndex("dbo.PageView", new[] { "ForeignId" });
            DropIndex("dbo.NoteType", new[] { "ForeignId" });
            DropIndex("dbo.Note", new[] { "ForeignId" });
            DropIndex("dbo.MetricValue", new[] { "ForeignId" });
            DropIndex("dbo.Metric", new[] { "ForeignId" });
            DropIndex("dbo.MetricCategory", new[] { "ForeignId" });
            DropIndex("dbo.HtmlContent", new[] { "ForeignId" });
            DropIndex("dbo.History", new[] { "ForeignId" });
            DropIndex("dbo.Following", new[] { "ForeignId" });
            DropIndex("dbo.FinancialPledge", new[] { "ForeignId" });
            DropIndex("dbo.FinancialPersonSavedAccount", new[] { "ForeignId" });
            DropIndex("dbo.FinancialPersonBankAccount", new[] { "ForeignId" });
            DropIndex("dbo.FinancialTransactionDetail", new[] { "ForeignId" });
            DropIndex("dbo.FinancialScheduledTransactionDetail", new[] { "ForeignId" });
            DropIndex("dbo.FinancialScheduledTransaction", new[] { "ForeignId" });
            DropIndex("dbo.FinancialTransactionRefund", new[] { "ForeignId" });
            DropIndex("dbo.FinancialTransactionImage", new[] { "ForeignId" });
            DropIndex("dbo.FinancialGateway", new[] { "ForeignId" });
            DropIndex("dbo.FinancialTransaction", new[] { "ForeignId" });
            DropIndex("dbo.FinancialBatch", new[] { "ForeignId" });
            DropIndex("dbo.FinancialAccount", new[] { "ForeignId" });
            DropIndex("dbo.ExceptionLog", new[] { "ForeignId" });
            DropIndex("dbo.EntitySet", new[] { "ForeignId" });
            DropIndex("dbo.EntitySetItem", new[] { "ForeignId" });
            DropIndex("dbo.ContentChannelType", new[] { "ForeignId" });
            DropIndex("dbo.ContentChannel", new[] { "ForeignId" });
            DropIndex("dbo.ContentChannelItem", new[] { "ForeignId" });
            DropIndex("dbo.CommunicationTemplate", new[] { "ForeignId" });
            DropIndex("dbo.Communication", new[] { "ForeignId" });
            DropIndex("dbo.CommunicationRecipient", new[] { "ForeignId" });
            DropIndex("dbo.CommunicationRecipientActivity", new[] { "ForeignId" });
            DropIndex("dbo.SiteDomain", new[] { "ForeignId" });
            DropIndex("dbo.Site", new[] { "ForeignId" });
            DropIndex("dbo.PageRoute", new[] { "ForeignId" });
            DropIndex("dbo.PageContext", new[] { "ForeignId" });
            DropIndex("dbo.Page", new[] { "ForeignId" });
            DropIndex("dbo.Layout", new[] { "ForeignId" });
            DropIndex("dbo.BlockType", new[] { "ForeignId" });
            DropIndex("dbo.Block", new[] { "ForeignId" });
            DropIndex("dbo.BenevolenceResult", new[] { "ForeignId" });
            DropIndex("dbo.BenevolenceRequest", new[] { "ForeignId" });
            DropIndex("dbo.Auth", new[] { "ForeignId" });
            DropIndex("dbo.Audit", new[] { "ForeignId" });
            DropIndex("dbo.AuditDetail", new[] { "ForeignId" });
            DropIndex("dbo.AttributeValue", new[] { "ForeignId" });
            DropIndex("dbo.Attribute", new[] { "ForeignId" });
            DropIndex("dbo.AttributeQualifier", new[] { "ForeignId" });
            DropIndex("dbo.UserLogin", new[] { "ForeignId" });
            DropIndex("dbo.PhoneNumber", new[] { "ForeignId" });
            DropIndex("dbo.DataViewFilter", new[] { "ForeignId" });
            DropIndex("dbo.DataView", new[] { "ForeignId" });
            DropIndex("dbo.GroupMember", new[] { "ForeignId" });
            DropIndex("dbo.GroupScheduleExclusion", new[] { "ForeignId" });
            DropIndex("dbo.GroupTypeRole", new[] { "ForeignId" });
            DropIndex("dbo.GroupType", new[] { "ForeignId" });
            DropIndex("dbo.Schedule", new[] { "ForeignId" });
            DropIndex("dbo.Device", new[] { "ForeignId" });
            DropIndex("dbo.BinaryFileData", new[] { "ForeignId" });
            DropIndex("dbo.BinaryFileType", new[] { "ForeignId" });
            DropIndex("dbo.BinaryFile", new[] { "ForeignId" });
            DropIndex("dbo.Location", new[] { "ForeignId" });
            DropIndex("dbo.GroupLocation", new[] { "ForeignId" });
            DropIndex("dbo.SystemEmail", new[] { "ForeignId" });
            DropIndex("dbo.Group", new[] { "ForeignId" });
            DropIndex("dbo.FieldType", new[] { "ForeignId" });
            DropIndex("dbo.EntityType", new[] { "ForeignId" });
            DropIndex("dbo.Category", new[] { "ForeignId" });
            DropIndex("dbo.DefinedType", new[] { "ForeignId" });
            DropIndex("dbo.DefinedValue", new[] { "ForeignId" });
            DropIndex("dbo.Person", new[] { "ForeignId" });
            DropIndex("dbo.PersonAlias", new[] { "ForeignId" });
            DropIndex("dbo.Campus", new[] { "ForeignId" });
            DropIndex("dbo.Attendance", new[] { "ForeignId" });
            DropIndex("dbo.AttendanceCode", new[] { "ForeignId" });
            AlterColumn("dbo.PersonDuplicate", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.MergeTemplate", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowTrigger", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowLog", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workflow", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowActivity", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowActivityType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowActionType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowAction", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowActionForm", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.WorkflowActionFormAttribute", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tag", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.TaggedItem", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ServiceLog", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ServiceJob", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.RestController", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.RestAction", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Report", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ReportField", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PrayerRequest", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PluginMigration", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonViewed", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonBadge", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PageView", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.NoteType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Note", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.MetricValue", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Metric", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.MetricCategory", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.HtmlContent", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.History", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Following", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialPledge", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialPersonSavedAccount", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialPersonBankAccount", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialTransactionDetail", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialScheduledTransactionDetail", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialScheduledTransaction", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialTransactionRefund", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialTransactionImage", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialGateway", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialTransaction", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialBatch", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FinancialAccount", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ExceptionLog", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.EntitySet", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.EntitySetItem", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ContentChannelType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ContentChannel", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.ContentChannelItem", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommunicationTemplate", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Communication", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommunicationRecipient", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommunicationRecipientActivity", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.SiteDomain", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Site", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PageRoute", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PageContext", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Page", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Layout", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BlockType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Block", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BenevolenceResult", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BenevolenceRequest", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Auth", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Audit", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AuditDetail", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AttributeValue", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Attribute", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AttributeQualifier", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserLogin", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhoneNumber", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.DataViewFilter", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.DataView", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupMember", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupScheduleExclusion", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupTypeRole", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Schedule", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Device", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BinaryFileData", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BinaryFileType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BinaryFile", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Location", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupLocation", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.SystemEmail", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Group", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.FieldType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.EntityType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Category", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.DefinedType", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.DefinedValue", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Person", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonAlias", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Campus", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Attendance", "ForeignId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AttendanceCode", "ForeignId", c => c.String(maxLength: 50));
        }
    }
}