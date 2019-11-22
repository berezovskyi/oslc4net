﻿/*******************************************************************************
 * Copyright (c) 2013 IBM Corporation.
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * and Eclipse Distribution License v. 1.0 which accompanies this distribution.
 *
 * The Eclipse Public License is available at http://www.eclipse.org/legal/epl-v10.html
 * and the Eclipse Distribution License is available at
 * http://www.eclipse.org/org/documents/edl-v10.php.
 *
 * Contributors:
 *     Steve Pitschke  - initial API and implementation
 *******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OSLC4Net.Core.Attribute;
using OSLC4Net.Core.Model;

namespace OSLC4Net.Core.Resources
{
    [OslcResourceShape(title = "Quality Management Resource Shape", describes = new string[] { QmConstants.TYPE_TEST_PLAN })]
    [OslcNamespace(QmConstants.QUALITY_MANAGEMENT_NAMESPACE)]
    /// <summary>
    /// http://open-services.net/bin/view/Main/QmSpecificationV2#Resource_TestPlan
    /// </summary>
    public class TestPlan : QmResource
    {
        private readonly ISet<Uri> contributors = new HashSet<Uri>(); // XXX - TreeSet<> in Java
        private readonly ISet<Uri> creators = new HashSet<Uri>(); // XXX - TreeSet<> in Java
        private readonly ISet<Link> relatedChangeRequests = new HashSet<Link>();
        private readonly ISet<String> subjects = new HashSet<String>(); // XXX - TreeSet<> in Java
        private readonly ISet<Link> usesTestCases = new HashSet<Link>();
        private readonly ISet<Link> validatesRequirementCollections = new HashSet<Link>();

        private String description;

        public TestPlan() : base()
        {
        }

        protected override Uri GetRdfType()
        {
            return new Uri(QmConstants.TYPE_TEST_PLAN);
        }

        public void AddContributor(Uri contributor)
        {
            contributors.Add(contributor);
        }

        public void AddCreator(Uri creator)
        {
            creators.Add(creator);
        }

        public void AddRelatedChangeRequest(Link relatedChangeRequest)
        {
            relatedChangeRequests.Add(relatedChangeRequest);
        }

        public void AddSubject(String subject)
        {
            subjects.Add(subject);
        }

        public void AddUsesTestCase(Link testcase)
        {
            usesTestCases.Add(testcase);
        }

        public void AddValidatesRequirementCollection(Link requirementCollection)
        {
            validatesRequirementCollections.Add(requirementCollection);
        }

        [OslcDescription("The person(s) who are responsible for the work needed to complete the change request.")]
        [OslcName("contributor")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "contributor")]
        [OslcRange(QmConstants.TYPE_PERSON)]
        [OslcTitle("Contributors")]
        public Uri[] GetContributors()
        {
            return contributors.ToArray();
        }

        [OslcDescription("Creator or creators of resource.")]
        [OslcName("creator")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "creator")]
        [OslcRange(QmConstants.TYPE_PERSON)]
        [OslcTitle("Creators")]
        public Uri[] GetCreators()
        {
            return creators.ToArray();
        }

        [OslcDescription("Descriptive text (reference: Dublin Core) about resource represented as rich text in XHTML content.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "description")]
        [OslcTitle("Description")]
        [OslcValueType(Core.Model.ValueType.XMLLiteral)]
        public String GetDescription()
        {
            return description;
        }

        [OslcDescription("A related change request.")]
        [OslcName("relatedChangeRequest")]
        [OslcPropertyDefinition(QmConstants.QUALITY_MANAGEMENT_NAMESPACE + "relatedChangeRequest")]
        [OslcRange(QmConstants.TYPE_CHANGE_REQUEST)]
        [OslcReadOnly(false)]
        [OslcTitle("Related Change Requests")]
        public Link[] GetRelatedChangeRequests()
        {
            return relatedChangeRequests.ToArray();
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public String[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Test Case used by the Test Plan.")]
        [OslcName("usesTestCase")]
        [OslcPropertyDefinition(QmConstants.QUALITY_MANAGEMENT_NAMESPACE + "usesTestCase")]
        [OslcRange(QmConstants.TYPE_TEST_CASE)]
        [OslcReadOnly(false)]
        [OslcTitle("Uses Test Case")]
        public Link[] GetUsesTestCases()
        {
            return usesTestCases.ToArray();
        }

        [OslcDescription("Requirement Collection that is validated by the Test Plan.")]
        [OslcName("validatesRequirementCollection")]
        [OslcPropertyDefinition(QmConstants.QUALITY_MANAGEMENT_NAMESPACE + "validatesRequirementCollection")]
        [OslcRange(QmConstants.TYPE_REQUIREMENT_COLLECTION)]
        [OslcReadOnly(false)]
        [OslcTitle("Validates Requirement Collection")]
        public Link[] GetValidatesRequirementCollections()
        {
            return validatesRequirementCollections.ToArray();
        }

        public void SetContributors(Uri[] contributors)
        {
            this.contributors.Clear();

            if (contributors != null)
            {
                this.contributors.AddAll(contributors);
            }
        }

        public void SetCreators(Uri[] creators)
        {
            this.creators.Clear();

            if (creators != null)
            {
                this.creators.AddAll(creators);
            }
        }

        public void SetDescription(String description)
        {
            this.description = description;
        }

        public void SetRelatedChangeRequests(Link[] relatedChangeRequests)
        {
            this.relatedChangeRequests.Clear();

            if (relatedChangeRequests != null)
            {
                this.relatedChangeRequests.AddAll(relatedChangeRequests);
            }
        }

        public void SetSubjects(String[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetUsesTestCases(Link[] usesTestCases)
        {
            this.usesTestCases.Clear();

            if (usesTestCases != null)
            {
                this.usesTestCases.AddAll(usesTestCases);
            }
        }

        public void SetValidatesRequirementCollections(Link[] validatesRequirementCollections)
        {
            this.validatesRequirementCollections.Clear();

            if (validatesRequirementCollections != null)
            {
                this.validatesRequirementCollections.AddAll(validatesRequirementCollections);
            }
        }
    }
}
